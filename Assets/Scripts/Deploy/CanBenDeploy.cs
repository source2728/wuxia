using System.Collections.Generic;

public class CanBenDeploy
{
    public struct Info
    {
        public string Name;
        public ESkillType Type;
        public EGoodsQuality Quality;
        public EDiff Difficulty;
        public EAttrType CondAttrType;
        public int CondAttrValue;
        public int Value;
        public string Desc;
        public string Icon;
    }

    public static Dictionary<int, Info> Datas = new Dictionary<int, Info>()
    {
        {1, new Info() {Name = "轻灵剑法", Type = ESkillType.JianFa, Difficulty = EDiff.Low, Quality = EGoodsQuality.None, CondAttrType = EAttrType.WuXing, CondAttrValue = 100, Value = 1000,
            Desc = "传自华山的轻灵剑法，失传已久，非常罕见。", Icon = "can_jian_03"}},
        {2, new Info() {Name = "迂回剑法", Type = ESkillType.JianFa, Difficulty = EDiff.Medium, Quality = EGoodsQuality.None, CondAttrType = EAttrType.WuXing, CondAttrValue = 200, Value = 2000,
            Desc = "传自峨嵋的迂回剑法，失传已久，非常罕见。", Icon = "can_jian_02"}},
        {3, new Info() {Name = "霸道剑法", Type = ESkillType.JianFa, Difficulty = EDiff.High, Quality = EGoodsQuality.None, CondAttrType = EAttrType.WuXing, CondAttrValue = 300, Value = 3000,
            Desc = "传自全真的霸道剑法，失传已久，非常罕见。", Icon = "can_jian_01"}},
        {4, new Info() {Name = "绝快剑法", Type = ESkillType.JianFa, Difficulty = EDiff.Hard, Quality = EGoodsQuality.None, CondAttrType = EAttrType.WuXing, CondAttrValue = 500, Value = 5000,
            Desc = "传自剑魔的绝快剑法，失传已久，非常罕见。", Icon = "can_jian_04"}},

        {5, new Info() {Name = "强攻刀法", Type = ESkillType.DaoFa, Difficulty = EDiff.Low, Quality = EGoodsQuality.None, CondAttrType = EAttrType.WuXing, CondAttrValue = 100, Value = 1000,
            Desc = "传自五毒的强攻刀法，失传已久，非常罕见。", Icon = "can_dao_02"}},
        {6, new Info() {Name = "刚猛刀法", Type = ESkillType.DaoFa, Difficulty = EDiff.Medium, Quality = EGoodsQuality.None, CondAttrType = EAttrType.WuXing, CondAttrValue = 200, Value = 2000,
            Desc = "传自丐帮的刚猛刀法，失传已久，非常罕见。", Icon = "can_dao_03"}},
        {7, new Info() {Name = "阴柔刀法", Type = ESkillType.DaoFa, Difficulty = EDiff.High, Quality = EGoodsQuality.None, CondAttrType = EAttrType.WuXing, CondAttrValue = 300, Value = 3000,
            Desc = "传自古墓的阴柔刀法，失传已久，非常罕见。", Icon = "can_dao_04"}},
        {8, new Info() {Name = "缓慢刀法", Type = ESkillType.DaoFa, Difficulty = EDiff.Hard, Quality = EGoodsQuality.None, CondAttrType = EAttrType.WuXing, CondAttrValue = 500, Value = 5000,
            Desc = "传自西域的缓慢刀法，失传已久，非常罕见。", Icon = "can_dao_01"}},
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
