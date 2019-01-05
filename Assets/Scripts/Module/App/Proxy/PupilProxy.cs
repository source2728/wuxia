using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PupilProxy : SingletonProxy, ILocalStorage
{

    public const string Name = "PupilProxy";
    public const string LocalStorageKey = "Pupil";
    public static readonly PupilProxy instance = new PupilProxy(null);

    private int NextUid = 0;

    PupilProxy(object data) : base(Name, data)
    {
        Data = new Dictionary<int, PupilData>();
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

        var data = JsonUtility.FromJson<Serialization<int, PupilData>>(strJson).ToDictionary();
        if (data != null && data.Count > 0)
        {
            Data = data;

            NextUid = 0;
            foreach (var pupilData in data)
            {
                if (pupilData.Key > NextUid)
                {
                    NextUid = pupilData.Key;
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
        var data = Data as Dictionary<int, PupilData>;
        var strJson = JsonUtility.ToJson(new Serialization<int, PupilData>(data));
        Debug.Log("PupilProxy Json:" + strJson);
        PlayerPrefs.SetString(LocalStorageKey, strJson);
    }

    public void resetData()
    {
        NextUid = 0;
        var dataMap = new Dictionary<int, PupilData>();
        foreach (var data in PupilDeploy.Datas)
        {
            var pupilData = new PupilData();
            pupilData.DId = data.Key;
            pupilData.Level = 1;
            pupilData.MaxExp = 200;
            pupilData.CurExp = 0;
            pupilData.SetAttr(EAttrType.WuXing, data.Value.BaseAttr.WuXing);
            pupilData.SetAttr(EAttrType.ZiZhi, data.Value.BaseAttr.ZiZhi);
            pupilData.SetAttr(EAttrType.WaiGong, data.Value.BaseAttr.WaiGong);
            pupilData.SetAttr(EAttrType.NeiGong, data.Value.BaseAttr.NeiGong);
            pupilData.SetAttr(EAttrType.ShenFa, data.Value.BaseAttr.ShenFa);
            pupilData.SetAttr(EAttrType.ShengMing, data.Value.BaseAttr.ShengMing);
            pupilData.SetAttr(EAttrType.ZhenQi, data.Value.BaseAttr.ZhenQi);
            pupilData.SetAttr(EAttrType.GongJi, data.Value.BaseAttr.GongJi);
            pupilData.SetAttr(EAttrType.FangYu, data.Value.BaseAttr.FangYu);
            pupilData.SetAttr(EAttrType.MingZhong, data.Value.BaseAttr.MingZhong);
            pupilData.SetAttr(EAttrType.ShanBi, data.Value.BaseAttr.ShanBi);
            pupilData.SetAttr(EAttrType.BaoJi, data.Value.BaseAttr.BaoJi);
            pupilData.SetAttr(EAttrType.KangBao, data.Value.BaseAttr.KangBao);
            dataMap.Add(++NextUid, pupilData);
        }
        Data = dataMap;
    }

    public int[] GetPupilIds()
    {
        var data = Data as Dictionary<int, PupilData>;
        return data.Keys.ToArray();
    }

    public PupilData getPupilInfo(int id)
    {
        var data = Data as Dictionary<int, PupilData>;
        PupilData resData;
        if (data.TryGetValue(id, out resData))
        {
            return resData;
        }
        return null;
    }
}
