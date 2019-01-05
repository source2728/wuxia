using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

public class UniqueSkillProxy : SingletonProxy, ILocalStorage
{
    public const string Name = "UniqueSkillProxy";
    public const string LocalStorageKey = "UniqueSkill";
    public static readonly UniqueSkillProxy instance = new UniqueSkillProxy(null);

    protected Dictionary<int, UniqueSkillData> _UniqueSkillMap;
    public Dictionary<int, UniqueSkillData> UniqueSkillMap
    {
        get { return _UniqueSkillMap; }
        set
        {
            _UniqueSkillMap = value;
            Data = value;
        }
    }

    private int NextUid = 0;

    UniqueSkillProxy(object data) : base(Name, data)
    {
        UniqueSkillMap = new Dictionary<int, UniqueSkillData>();
    }

    public void loadData()
    {
        var strJson = PlayerPrefs.GetString(LocalStorageKey);
        if (strJson == "")
        {
            resetData();
            saveData();
            return;
        }

        var data = JsonUtility.FromJson<Serialization<int, UniqueSkillData>>(strJson).ToDictionary();
        if (data != null && data.Count > 0)
        {
            UniqueSkillMap = data;

            NextUid = 0;
            foreach (var uniqueSkill in UniqueSkillMap)
            {
                if (uniqueSkill.Key > NextUid)
                {
                    NextUid = uniqueSkill.Key;
                }
            }
        }
        else
        {
            resetData();
            saveData();
        }
    }

    public void saveData()
    {
        var strJson = JsonUtility.ToJson(new Serialization<int, UniqueSkillData>(UniqueSkillMap));
        Debug.Log("UniqueSkillProxy Json:" + strJson);
        PlayerPrefs.SetString(LocalStorageKey, strJson);
    }

    public void resetData()
    {
        NextUid = 0;
        UniqueSkillMap = new Dictionary<int, UniqueSkillData>();
    }

    [CanBeNull]
    public UniqueSkillData GetData(int id)
    {
        UniqueSkillData data;
        if (UniqueSkillMap.TryGetValue(id, out data))
        {
            return data;
        }
        return null;
    }

    public UniqueSkillData CreateUniqueSkill(SkillCreateData data, string name)
    {
        var pupilDeploy = PupilDeploy.GetInfo(data.PupilId);

        var uniqueSkillInfo = new UniqueSkillData();
        uniqueSkillInfo.Id = ++NextUid;
        uniqueSkillInfo.Name = name;
        uniqueSkillInfo.CreatorName = pupilDeploy.Name;
        uniqueSkillInfo.SkillId1 = data.SkillType;
        uniqueSkillInfo.SkillId2 = data.SkillId;
        uniqueSkillInfo.Quality = GetQuality(data);
        uniqueSkillInfo.DiffValue = data.Diff;
        uniqueSkillInfo.Level = 1;
        uniqueSkillInfo.PracticePerLevel = 100;
        uniqueSkillInfo.Attr = new PupilAttr();
        uniqueSkillInfo.SkillEffectId = 1;
        uniqueSkillInfo.Value = data.Value;

        UniqueSkillMap.Add(uniqueSkillInfo.Id, uniqueSkillInfo);
        return uniqueSkillInfo;
    }

    private EGoodsQuality GetQuality(SkillCreateData data)
    {
        int value = (data.BasePower + data.SkillPower + data.Value - data.Diff) / 4;
        if (value <= 1000)
            return EGoodsQuality.FanPin;
        else if (value <= 2000)
            return EGoodsQuality.ZhenPin;
        else if (value <= 3000)
            return EGoodsQuality.ChaoPin;
        else if (value <= 4000)
            return EGoodsQuality.JiPin;
        else
            return EGoodsQuality.JuePin;
    }
}
