using System;
using UnityEngine;

public class ExploreProxy : SingletonProxy, ILocalStorage
{
    public const string Name = "ExploreProxy";
    public const string LocalStorageKey = "Explore";
    public const string NotifySkillCreateUpdated = "NotifySkillCreateUpdated";

    public static readonly ExploreProxy instance = new ExploreProxy(null);

    ExploreProxy(object data) : base(Name, data)
    {
        Data = new ExploreData();
    }

    public ExploreData GetData()
    {
        return Data as ExploreData;
    }

    public void loadData()
    {
        var data = JsonUtility.FromJson<ExploreData>(PlayerPrefs.GetString(LocalStorageKey));
        if (data != null)
        {
            Data = data;
//            CreateSimulate();
        }
        else
        {
            resetData();
            saveData();
        }
    }

    public void saveData()
    {
        var strJson = JsonUtility.ToJson(Data);
        PlayerPrefs.SetString(LocalStorageKey, strJson);
        Debug.Log("ExploreProxy Json:" + strJson);
    }

    public void resetData()
    {
        Data = new ExploreData();
    }

    public void StartExplore(ExploreData exploreData)
    {
        var data = Data as ExploreData;
        data.StartTime = TimeUtil.CurrentTime();
        data.FinishTime = data.StartTime + 30;
        data.PlaceId = exploreData.PlaceId;
        data.PupilId1 = exploreData.PupilId1;
        data.PupilId2 = exploreData.PupilId2;

        TimeTickService.inst.AddTimeTick(30, OnTickFinishExplore);
    }

    private bool OnTickFinishExplore()
    {
        Facade.SendNotification(ExploreFacade.NotifyExploreTimeUp);
        return true;
    }

    public ExploreData FinishExplore()
    {
        var data = Data as ExploreData;
        Data = new ExploreData();
        return data;
    }
}
