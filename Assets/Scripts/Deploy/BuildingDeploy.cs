using System.Collections.Generic;

public enum EBuilding
{
    WuDing = 1,
    ShangPu = 2,
    WaiGongFang = 3,
    ZhengDian = 4,
}

public class BuildingDeploy
{
    public struct Info
    {
        public int MaxLevel;
        public int OpenType;
        public int OpenLevel;
        public string Name;
    }

    public static Dictionary<int, Info> Datas = new Dictionary<int, Info>()
    {
        {(int)EBuilding.WuDing, new Info() {MaxLevel = 1, OpenType = 1, OpenLevel = 0, Name = "屋顶"}},
        {(int)EBuilding.ShangPu, new Info() {MaxLevel = 30, OpenType = 2, OpenLevel = 3, Name = "商铺"}},
        {(int)EBuilding.WaiGongFang, new Info() {MaxLevel = 30, OpenType = 2, OpenLevel = 2, Name = "外功房"}},
        {(int)EBuilding.ZhengDian, new Info() {MaxLevel = 30, OpenType = 1, OpenLevel = 0, Name = "正殿"}},
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
