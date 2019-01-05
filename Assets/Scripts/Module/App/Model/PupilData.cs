using System;
using System.Collections.Generic;

[Serializable]
public class PupilData
{
    public int DId = 0;
    public int Level = 0;
    public int[] Attrs = new int[(int)EAttrType.Count];
    public List<ItemData> EquipItems = new List<ItemData>();

    public int MaxExp = 0;
    public int CurExp = 0;

    public PupilDeploy.Info GetDeploy()
    {
        return PupilDeploy.GetInfo(DId);
    }

    public int GetCombat()
    {
        int total = 0;
        foreach (var attr in Attrs)
        {
            total += attr;
        }
        total *= 10;
        return total;
    }

    public void SetAttr(EAttrType type, int value)
    {
        Attrs[(int)type] = value;
    }

    public int GetAttr(EAttrType type)
    {
        return Attrs[(int) type];
    }

    public ItemData GetEquipingWuXue()
    {
        foreach (var item in EquipItems)
        {
            if (item.Type == EGoodsType.WuXue)
            {
                return item;
            }
        }

        return null;
    }
}
