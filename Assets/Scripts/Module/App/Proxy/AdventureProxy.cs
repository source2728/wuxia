using System.Collections.Generic;
using UnityEngine;

public class AdventureProxy : SingletonProxy, ILocalStorage
{
    public const string Name = "AdventureProxy";
    public const string LocalStorageKey = "Adventure";
    public static readonly AdventureProxy instance = new AdventureProxy(null);

    AdventureProxy(object data) : base(Name, data)
    {
        Data = new AdventureData();
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

        var data = JsonUtility.FromJson<AdventureData>(strJson);
        if (data != null)
        {
            Data = data;
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
        Debug.Log("AdventureProxy Json:" + strJson);
        PlayerPrefs.SetString(LocalStorageKey, JsonUtility.ToJson(Data));
    }

    public void resetData()
    {
        Data = new AdventureData();
    }

    public void AddDropGoodsRecord(ItemData goodsData)
    {
        var data = Data as AdventureData;
        data.GoodsList.Add(goodsData);
    }

    public void StartAdventure(int pupilId)
    {
        var data = new AdventureData();
        data.PupilId = pupilId;
        Data = data;
    }

    public void FinishAdventure()
    {
        Data = new AdventureData();
    }

    public AdventureData GetData()
    {
        return Data as AdventureData;
    }
}
