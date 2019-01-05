using System.Collections.Generic;

public class PlaceDeploy
{
    public struct Info
    {
        public int Level;
        public string Name;
        public float EventPro;
        public GoodsAddAttr AddAtt;
        public string GoodAt;
    }

    public static Dictionary<int, Info> Datas = new Dictionary<int, Info>()
    {
        {1, new Info() {Name = "少林", Level = 10, EventPro = 0.6f, GoodAt = "内功", AddAtt = new GoodsAddAttr(){AddWaiGong = 10, AddNeiGong = 20, AddShenFa = 0, AddJianFa = 5, AddDaoFa = 5}}},
        {2, new Info() {Name = "武当", Level = 20, EventPro = 0.7f, GoodAt = "内功", AddAtt = new GoodsAddAttr(){AddWaiGong = 10, AddNeiGong = 20, AddShenFa = 0, AddJianFa = 10, AddDaoFa = 0}}},
        {3, new Info() {Name = "峨嵋", Level = 30, EventPro = 0.8f, GoodAt = "身法", AddAtt = new GoodsAddAttr(){AddWaiGong = 0, AddNeiGong = 10, AddShenFa = 20, AddJianFa = 10, AddDaoFa = 0}}},
        {4, new Info() {Name = "丐帮", Level = 40, EventPro = 0.9f, GoodAt = "外功", AddAtt = new GoodsAddAttr(){AddWaiGong = 20, AddNeiGong = 10, AddShenFa = 0, AddJianFa = 0, AddDaoFa = 10}}},
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
