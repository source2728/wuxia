using System;

[Serializable]
public class ItemData
{
    public int Id = 0;     // 配置表id
    public EGoodsType Type = EGoodsType.None;
    public int Count = 0;

    public EGoodsQuality Quality;
    public int Value = 0;

    public string Name = "";
    public string Desc = "";
}
