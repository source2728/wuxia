using UnityEngine;

public class SkillCreateProxy : SingletonProxy, ILocalStorage
{

    public const string Name = "SkillCreateProxy";
    public const string LocalStorageKey = "SkillCreate";
    public const string NotifySkillCreateUpdated = "NotifySkillCreateUpdated";
    public const string NotifyChokeStart = "NotifyChokeStart";
    public const string NotifyEventSelectStart = "NotifyEventSelectStart";
    public const string NotifyCreateFinished = "NotifyCreateFinished";
    public static readonly SkillCreateProxy instance = new SkillCreateProxy(null);

    protected UniqueSkillCreateDeploy.Info m_UniqueSkillCreateDeploy;

    SkillCreateProxy(object data) : base(Name, data)
    {
        Data = new SkillCreateData();
    }

    public SkillCreateData GetData()
    {
        return Data as SkillCreateData;
    }

    public void loadData()
    {
        var data = JsonUtility.FromJson<SkillCreateData>(PlayerPrefs.GetString(LocalStorageKey));
        if (data != null)
        {
            Data = data;
            CreateSimulate();
        }
        else
        {
            resetData();
            saveData();
        }
    }

    public void saveData()
    {
        PlayerPrefs.SetString(LocalStorageKey, JsonUtility.ToJson(Data));
    }

    public void resetData()
    {
        Data = new SkillCreateData();
    }

    public bool isCreatingSkill()
    {
        var data = Data as SkillCreateData;
        return data.PupilId > 0;
    }

    public SkillCreateData getData()
    {
        return Data as SkillCreateData;
    }

    protected void StartCreate()
    {
        var info = Data as SkillCreateData;
        TimeTickService.inst.AddTimeTick(1, OnTickCreateUniqueSkill);
        m_UniqueSkillCreateDeploy = UniqueSkillCreateDeploy.GetInfo(info.SkillType, info.SkillId).Value;
    }

    public void startCreateSkill(SkillCreateData data)
    {
        var curTime = TimeUtil.ConvertDateTimeToLong(System.DateTime.Now);

        var info = new SkillCreateData();
        info.PupilId = data.PupilId;
        info.SkillType = data.SkillType;
        info.SkillId = data.SkillId;

        info.TotalTime = 1 * 60;
        info.StartTime = curTime;
        info.ChokeStartTime = info.StartTime + (long)(info.TotalTime * 0.6);
        info.EventStartTime = 0;
        info.FinishTime = 0;

        Data = info;
        StartCreate();
    }

    private void CreateSimulate()
    {
        var info = Data as SkillCreateData;
        if (info.LastCreateTime <= 0)
        {
            return;
        }
        var curTimeNow = TimeUtil.CurrentTime();
        var curTime = info.LastCreateTime;

        var deploy = UniqueSkillCreateDeploy.GetInfo(info.SkillType, info.SkillId);
        if (deploy == null)
        {
            return;
        }
        m_UniqueSkillCreateDeploy = deploy.Value;
        while (curTime < curTimeNow)
        {
            if (info.FinishTime > 0 && info.FinishTime <= curTime)
            {
                break;
            }

            if (info.EventStartTime > 0 && info.EventFinishTime <= 0 && info.EventStartTime <= curTime)
            {
                break;
            }

            if (info.ChokeStartTime > 0 && info.ChokeFinishTime <= 0 && info.ChokeStartTime <= curTime)
            {
                break;
            }

            info.BasePower += Random.Range(m_UniqueSkillCreateDeploy.AttrPSMin.BasePower, m_UniqueSkillCreateDeploy.AttrPSMax.BasePower + 1);
            info.SkillPower += Random.Range(m_UniqueSkillCreateDeploy.AttrPSMin.SkillPower, m_UniqueSkillCreateDeploy.AttrPSMax.SkillPower + 1);
            info.Value += Random.Range(m_UniqueSkillCreateDeploy.AttrPSMin.Value, m_UniqueSkillCreateDeploy.AttrPSMax.Value + 1);
            info.Diff += Random.Range(m_UniqueSkillCreateDeploy.AttrPSMin.Diff, m_UniqueSkillCreateDeploy.AttrPSMax.Diff + 1);
            info.LastCreateTime = curTime;
            curTime++;
        }

        if (info.FinishTime > 0 && info.FinishTime > curTimeNow)
        {
            StartCreate();
            return;
        }

        if (info.EventStartTime > 0 && info.EventStartTime > curTimeNow)
        {
            StartCreate();
            return;
        }

        if (info.ChokeStartTime > 0 && info.ChokeStartTime > curTimeNow)
        {
            StartCreate();
            return;
        }
    }

    private bool OnTickCreateUniqueSkill()
    {
        var curTime = TimeUtil.CurrentTime();
        var info = Data as SkillCreateData;

        info.LastAddBasePower = Random.Range(m_UniqueSkillCreateDeploy.AttrPSMin.BasePower, m_UniqueSkillCreateDeploy.AttrPSMax.BasePower);
        info.LastAddSkillPower = Random.Range(m_UniqueSkillCreateDeploy.AttrPSMin.SkillPower, m_UniqueSkillCreateDeploy.AttrPSMax.SkillPower);
        info.LastAddValue = Random.Range(m_UniqueSkillCreateDeploy.AttrPSMin.Value, m_UniqueSkillCreateDeploy.AttrPSMax.Value);
        info.LastAddDiff = Random.Range(m_UniqueSkillCreateDeploy.AttrPSMin.Diff, m_UniqueSkillCreateDeploy.AttrPSMax.Diff);

        info.BasePower += info.LastAddBasePower;
        info.SkillPower += info.LastAddSkillPower;
        info.Value += info.LastAddValue;
        info.Diff += info.LastAddDiff;
        info.LastCreateTime = curTime;
        AppFacade.getInstance().SendNotification(NotifySkillCreateUpdated);

        if (info.FinishTime > 0 && info.FinishTime <= curTime)
        {
            AppFacade.getInstance().SendNotification(NotifyCreateFinished);
            return true;
        }

        if (info.EventStartTime > 0 && info.EventFinishTime <= 0 && info.EventStartTime <= curTime)
        {
            AppFacade.getInstance().SendNotification(NotifyEventSelectStart);
            return true;
        }

        if (info.ChokeStartTime > 0 && info.ChokeFinishTime <= 0 && info.ChokeStartTime <= curTime)
        {
            AppFacade.getInstance().SendNotification(NotifyChokeStart);
            return true;
        }

        return false;
    }

    public void finishCreateSkill()
    {
        Data = new SkillCreateData();
    }

    public void giveUpEvent()
    {
        var curTime = TimeUtil.ConvertDateTimeToLong(System.DateTime.Now);

        var data = Data as SkillCreateData;
        data.ChokeFinishTime = curTime;
        data.EventStartTime = curTime;
        data.EventFinishTime = curTime;
        data.FinishTime = curTime + data.TotalTime - (data.ChokeStartTime - data.StartTime);

        StartCreate();
    }

    public void tryEvent(int placeId)
    {
        var curTime = TimeUtil.ConvertDateTimeToLong(System.DateTime.Now);

        var data = Data as SkillCreateData;
        if (Random.Range(0, 1) <= 0.8)
        {
            data.ChokeFinishTime = curTime;
            data.EventStartTime = curTime + (long)((data.TotalTime - (data.ChokeStartTime - data.StartTime)) * 0.5);
            data.FinishTime = 0;
        }
        else
        {
            data.ChokeFinishTime = curTime;
            data.EventStartTime = curTime;
            data.EventFinishTime = curTime;
            data.FinishTime = curTime + (data.TotalTime - (data.ChokeStartTime - data.StartTime));
        }
        data.PlaceId = placeId;

        StartCreate();
    }

    public void selectPowerUpEvent()
    {
        var curTime = TimeUtil.ConvertDateTimeToLong(System.DateTime.Now);

        var data = Data as SkillCreateData;
        data.EventFinishTime = curTime;
        data.FinishTime = curTime + (data.TotalTime - (data.ChokeStartTime - data.StartTime) - (data.EventStartTime - data.ChokeFinishTime));
        data.EventType = 1;

        StartCreate();
    }

    public void BasePowerUp(int percent)
    {
        var data = Data as SkillCreateData;
        data.AppendAddBasePower = (int)(data.BasePower * percent / 100f);
        data.BasePower += data.AppendAddBasePower;
    }

    public void selectQualityUpEvent()
    {
        var curTime = TimeUtil.ConvertDateTimeToLong(System.DateTime.Now);

        var data = Data as SkillCreateData;
        data.EventFinishTime = curTime;
        data.FinishTime = curTime + (data.TotalTime - (data.ChokeStartTime - data.StartTime) - (data.EventStartTime - data.ChokeFinishTime));
        data.EventType = 2;

        StartCreate();
    }

    public void SkillPowerUp(int percent)
    {
        var data = Data as SkillCreateData;
        data.AppendAddSkillPower = (int)(data.SkillPower * percent / 100f);
        data.SkillPower += data.AppendAddSkillPower;
    }
}
