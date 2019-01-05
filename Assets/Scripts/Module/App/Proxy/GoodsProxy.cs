using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GoodsProxy : SingletonProxy, ILocalStorage
{
    public const string Name = "GoodsProxy";
    public const string LocalStorageKey = "Item";
    public static readonly GoodsProxy instance = new GoodsProxy(null);
    protected const int TypeScope = 100000;

    protected Dictionary<int, ItemData> _GoodsMap;
    public Dictionary<int, ItemData> GoodsMap
    {
        get { return _GoodsMap; }
        set
        {
            _GoodsMap = value;
            Data = value;
        }
    }

    GoodsProxy(object data) : base(Name, data)
    {
        GoodsMap = new Dictionary<int, ItemData>();
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

        var data = JsonUtility.FromJson<Serialization<int, ItemData>>(strJson).ToDictionary();
        if (data != null && data.Count > 0)
        {
            GoodsMap = data;
        }
        else
        {
            resetData();
            saveData();
        }
    }

    public void saveData()
    {
        var strJson = JsonUtility.ToJson(new Serialization<int, ItemData>(GoodsMap));
        Debug.Log("GoodsProxy Json:" + strJson);
        PlayerPrefs.SetString(LocalStorageKey, strJson);
    }

    public void resetData()
    {
        GoodsMap.Clear();
        for (int i = 1; i <= GoodsDeploy.Datas.Count; i++)
        {
            AddItem(i, EGoodsType.DaoJu, 10);
        }
        for (int i = 1; i <= CanBenDeploy.Datas.Count; i++)
        {
            AddItem(i, EGoodsType.CanBen, 10);
        }
        for (int i = 1; i <= XinFaDeploy.Datas.Count; i++)
        {
            AddItem(i, EGoodsType.XinFa, 10);
        }
    }

    public ItemData AddItem(int itemId, EGoodsType type, int count)
    {
        int key = (int)type * TypeScope + itemId;

        ItemData itemInfo;
        if (GoodsMap.TryGetValue(key, out itemInfo))
        {
            itemInfo.Count += count;
        }
        else
        {
            itemInfo = new ItemData();
            itemInfo.Id = itemId;
            itemInfo.Type = type;
            itemInfo.Count = count;

            switch (type)
            {
                case EGoodsType.DaoJu:
                {
                    var deploy = GoodsDeploy.GetInfo(itemId);
                    itemInfo.Name = deploy.Name;
                    itemInfo.Value = deploy.Value;
                    itemInfo.Desc = deploy.Desc;
                    itemInfo.Quality = deploy.Quality;
                    break;
                }

                case EGoodsType.XinFa:
                {
                    var deploy = XinFaDeploy.GetInfo(itemId);
                    itemInfo.Name = deploy.Name;
                    itemInfo.Value = deploy.Value;
                    itemInfo.Desc = deploy.Desc;
                    itemInfo.Quality = deploy.Quality;
                    break;
                }

                case EGoodsType.CanBen:
                {
                    var deploy = CanBenDeploy.GetInfo(itemId);
                    itemInfo.Name = deploy.Name;
                    itemInfo.Value = deploy.Value;
                    itemInfo.Desc = deploy.Desc;
                    itemInfo.Quality = deploy.Quality;
                    break;
                }

                case EGoodsType.WuXue:
                {
                    var data = UniqueSkillProxy.instance.GetData(itemId);
                    itemInfo.Name = data.Name;
                    itemInfo.Value = data.Value;
                    itemInfo.Desc = data.Desc;
                    itemInfo.Quality = data.Quality;
                    break;
                }

                default:
                {
                    itemInfo.Name = "";
                    itemInfo.Value = 0;
                    itemInfo.Desc = "";
                    itemInfo.Quality = EGoodsQuality.None;
                    break;
                }
            }

            GoodsMap.Add(key, itemInfo);
        }

        return itemInfo;
    }

    public void RemoveItem(int itemId, EGoodsType type, int count)
    {
        int key = (int)type * TypeScope + itemId;

        ItemData itemInfo;
        if (GoodsMap.TryGetValue(key, out itemInfo))
        {
            itemInfo.Count -= count;
            if (itemInfo.Count <= 0)
            {
                GoodsMap.Remove(key);
            }
        }
    }

    public ItemData[] GetGoodsByType(EGoodsType type)
    {
        int minKey = (int) type * TypeScope;
        int maxKey = minKey + TypeScope - 1;

        List<ItemData> list = new List<ItemData>();
        foreach (var data in GoodsMap)
        {
            if (data.Key >= minKey && data.Key <= maxKey)
            {
                list.Add(data.Value);
            }
        }
        return list.ToArray();
    }
}
