using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System;


public class BuildingProxy : SingletonProxy, ILocalStorage
{

    public const string Name = "BuildingProxy";
    public const string LocalStorageKey = "Building";
    public static readonly BuildingProxy instance = new BuildingProxy(null);

    BuildingProxy(object data) : base(Name, data)
    {
        Data = new Dictionary<int, BuildData>();
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

        var data = JsonUtility.FromJson<Serialization<int, BuildData>>(strJson).ToDictionary();
        if (data != null && data.Count > 0)
        {
            Data = data;
        }
        else
        {
            this.resetData();
            this.saveData();
        }
    }

    public void saveData()
    {
        var data = Data as Dictionary<int, BuildData>;
        var strJson = JsonUtility.ToJson(new Serialization<int, BuildData>(data));
        Debug.Log("BuildingProxy Json:" + strJson);
        PlayerPrefs.SetString(LocalStorageKey, strJson);
    }

    public void resetData()
    {
        var data = new Dictionary<int, BuildData>();
        foreach (var item in BuildingDeploy.Datas)
        {
            if (item.Value.OpenType == 1)
            {
                data.Add(item.Key, new BuildData()
                {
                    Id = item.Key,
                    Level = 1,
                    IsShow = true,
                    IsLock = false
                });
            }
        }
        Data = data;
    }

    public BuildData getBuildingInfo(int buildingId)
    {
        var data = Data as Dictionary<int, BuildData>;
        BuildData res;
        if (data.TryGetValue(buildingId, out res))
            return res;
        return null;
    }

    public List<int> GetBuildingIds () 
    {
        var data = Data as Dictionary<int, BuildData>;
        List<int> ids = new List<int>();
        foreach (var key in data.Keys)
        {
            ids.Add(key);
        }
        return ids;
    }

    public void addBuilding(int buildingId, BuildData buildingInfo)
    {
        var data = Data as Dictionary<int, BuildData>;
        data[buildingId] = buildingInfo;
    }

    public void buildingUnlock(int buildingId)
    {
        var data = Data as Dictionary<int, BuildData>;
        var buildingInfo = data[buildingId];
        buildingInfo.Level = 1;
        buildingInfo.IsLock = false;
    }

    public void buildingLevelUp(int buildingId)
    {
        var data = Data as Dictionary<int, BuildData>;
        var buildingInfo = data[buildingId];
        buildingInfo.Level += 1;
    }
}
