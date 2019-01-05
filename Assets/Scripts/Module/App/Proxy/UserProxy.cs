using UnityEngine;

public class UserProxy : SingletonProxy, ILocalStorage
{
    public const string Name = "UserProxy";
    public const string LocalStorageKey = "User";
    public static readonly UserProxy instance = new UserProxy(null);

    UserProxy(object data) : base(Name, data)
    {
        Data = new UserData();
    }

    public void loadData()
    {
        var data = JsonUtility.FromJson<UserData>(PlayerPrefs.GetString(LocalStorageKey));
        if (data != null)
        {
            Data = data;
        }
        else
        {
            this.resetData();
            this.saveData();
        }
    }

    public UserData getData()
    {
        return Data as UserData;
    }

    public void saveData()
    {
        var strJson = JsonUtility.ToJson(Data);
        Debug.Log("UserProxy Json:" + strJson);
        PlayerPrefs.SetString(LocalStorageKey, JsonUtility.ToJson(Data));
    }

    public void resetData()
    {
        var data = new UserData();
        data.Gold = GlobalDeploy.InitGold;
        data.Honor = GlobalDeploy.InitHonor;
        Data = data;
    }

    public bool hasEnoughGold(int gold)
    {
        var data = Data as UserData;
        return data.Gold >= gold;
    }

    public void addGold(int gold)
    {
        var data = Data as UserData;
        data.Gold += gold;
    }

    public void costGold(int gold)
    {
        var data = Data as UserData;
        data.Gold -= gold;
    }

    public void addHonor(int honor)
    {
        var data = Data as UserData;
        data.Honor += honor;
    }
}
