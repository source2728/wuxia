using System.Collections.Generic;

public class GoodsDeploy
{
    public struct Info
    {
        public string Name;
        public EGoodsQuality Quality;
        public GoodsAddAttr AddAtt;
        public int Value;
        public string Desc;

        public int GetAddAttr(ESkillType type)
        {
            switch (type)
            {
                case ESkillType.WaiGong:
                    return AddAtt.AddWaiGong;

                case ESkillType.NeiGong:
                    return AddAtt.AddNeiGong;

                case ESkillType.ShenFa:
                    return AddAtt.AddShenFa;

                case ESkillType.JianFa:
                    return AddAtt.AddJianFa;

                case ESkillType.DaoFa:
                    return AddAtt.AddDaoFa;
            }

            return 0;
        }
    }

    public static Dictionary<int, Info> Datas = new Dictionary<int, Info>()
    {
        {1, new Info() {Name = "天山雪莲", Quality = EGoodsQuality.ZhenPin, Value = 1000, Desc = "天山雪莲是好东西",
            AddAtt = new GoodsAddAttr(){AddWaiGong = 5, AddNeiGong = 20, AddShenFa = 0, AddJianFa = 0, AddDaoFa = 0}}},
        {2, new Info() {Name = "千年人参", Quality = EGoodsQuality.ZhenPin, Value = 1000, Desc = "千年人参是好东西",
            AddAtt = new GoodsAddAttr(){AddWaiGong = 10, AddNeiGong = 20, AddShenFa = 0, AddJianFa = 0, AddDaoFa = 0}}},
        {3, new Info() {Name = "仙鹤玄玉", Quality = EGoodsQuality.ChaoPin, Value = 1000, Desc = "仙鹤玄玉是好东西",
            AddAtt = new GoodsAddAttr(){AddWaiGong = 0, AddNeiGong = 10, AddShenFa = 20, AddJianFa = 5, AddDaoFa = 0}}},
        {4, new Info() {Name = "龙须宝竹", Quality = EGoodsQuality.ChaoPin, Value = 1000, Desc = "龙须宝竹是好东西",
            AddAtt = new GoodsAddAttr(){AddWaiGong = 20, AddNeiGong = 5, AddShenFa = 10, AddJianFa = 0, AddDaoFa = 0}}},
        {5, new Info() {Name = "九张机", Quality = EGoodsQuality.JiPin, Value = 1000, Desc = "九张机是好东西",
            AddAtt = new GoodsAddAttr(){AddWaiGong = 20, AddNeiGong = 10, AddShenFa = 5, AddJianFa = 0, AddDaoFa = 0}}},
        {6, new Info() {Name = "十八泥偶", Quality = EGoodsQuality.JiPin, Value = 1000, Desc = "十八泥偶是好东西",
            AddAtt = new GoodsAddAttr(){AddWaiGong = 10, AddNeiGong = 20, AddShenFa = 5, AddJianFa = 0, AddDaoFa = 0}}},
        {7, new Info() {Name = "真武寒铁", Quality = EGoodsQuality.JuePin, Value = 1000, Desc = "真武寒铁是好东西",
            AddAtt = new GoodsAddAttr(){AddWaiGong = 5, AddNeiGong = 10, AddShenFa = 0, AddJianFa = 20, AddDaoFa = 0}}},
        {8, new Info() {Name = "千色琉璃", Quality = EGoodsQuality.JuePin, Value = 1000, Desc = "千色琉璃是好东西",
            AddAtt = new GoodsAddAttr(){AddWaiGong = 10, AddNeiGong = 10, AddShenFa = 10, AddJianFa = 5, AddDaoFa = 20}}},
        {9, new Info() {Name = "无心花", Quality = EGoodsQuality.JuePin, Value = 1000, Desc = "无心花是好东西",
            AddAtt = new GoodsAddAttr(){AddWaiGong = 20, AddNeiGong = 5, AddShenFa = 20, AddJianFa = 10, AddDaoFa = 10}}},
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