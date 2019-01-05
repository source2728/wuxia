using System.Collections.Generic;
using System.Linq;

public class BuyPlaceDeploy
{
    public struct Info
    {
        public string Name;
        public string Title1;
        public string Value1;
        public string Title2;
        public string Value2;
    }

    public static Dictionary<int, Info> Datas = new Dictionary<int, Info>()
    {
        {1, new Info() {Name = "少林", Title1 = "外功剑法", Value1 = "重金", Title2 = "内功剑法", Value2 = "一般"}},
        {2, new Info() {Name = "武当", Title1 = "外功剑法", Value1 = "重金", Title2 = "内功剑法", Value2 = "重金"}},
        {3, new Info() {Name = "峨眉", Title1 = "内功剑法", Value1 = "一般", Title2 = "身法剑法", Value2 = "一般"}},
        {4, new Info() {Name = "丐帮", Title1 = "外功刀法", Value1 = "一般", Title2 = "内功刀法", Value2 = "重金"}},
    };

    public static int[] GetIds()
    {
        return Datas.Keys.ToArray();
    }

    public static Info GetInfo(int id)
    {
        return Datas[id];
    }
}
