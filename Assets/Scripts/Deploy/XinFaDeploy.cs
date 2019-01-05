using System.Collections.Generic;

public class XinFaDeploy
{
    public struct Info
    {
        public string Name;
        public ESkillType Type;
        public EGoodsQuality Quality;
        public EAttrType CondAttrType;
        public int CondAttrValue;
        public int Value;
        public string Desc;
        public string Icon;
    }

    public static Dictionary<int, Info> Datas = new Dictionary<int, Info>()
    {
        {1, new Info() {Name = "太极心法", Type = ESkillType.NeiGong, Quality = EGoodsQuality.JiPin, CondAttrType = EAttrType.NeiGong, CondAttrValue = 200, Value = 500,
            Desc = "传自武当的内功心法，失传已久，非常罕见。", Icon = "xin_001"}},
        {2, new Info() {Name = "纯阳心法", Type = ESkillType.NeiGong, Quality = EGoodsQuality.JuePin, CondAttrType = EAttrType.NeiGong, CondAttrValue = 500, Value = 1000,
            Desc = "传自少林的内功心法，失传已久，非常罕见。", Icon = "xin_002"}},
        {3, new Info() {Name = "筋骨心法", Type = ESkillType.WaiGong, Quality = EGoodsQuality.JiPin, CondAttrType = EAttrType.WaiGong, CondAttrValue = 200, Value = 500,
            Desc = "传自天山的外功心法，失传已久，非常罕见。", Icon = "xin_003"}},
        {4, new Info() {Name = "玄脉心法", Type = ESkillType.WaiGong, Quality = EGoodsQuality.JuePin, CondAttrType = EAttrType.WaiGong, CondAttrValue = 500, Value = 1000,
            Desc = "传自魔教的外功心法，失传已久，非常罕见。", Icon = "xin_004"}},
    };

    public static int[] GetIds()
    {
        int index = 0;
        int[] ids = new int[Datas.Count];
        foreach (var key in Datas.Keys)
        {
            ids[index++] = key;
        }
        return ids;
    }

    public static Info GetInfo(int id)
    {
        return Datas[id];
    }
}
