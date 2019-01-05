using System.Collections.Generic;
using System.Linq;

public class WantSellDeploy
{
    public struct Info
    {
        public string Name;
        public string Desc;
        public int Value;
    }

    public static Dictionary<int, Info> Datas = new Dictionary<int, Info>()
    {
        {1, new Info() {Name = "方丈不二", Desc = "真是难得一见的旷世绝学，少林出价40000两求购", Value = 40000}},
        {2, new Info() {Name = "掌门九阳", Desc = "一般般啦，最多值20000两", Value = 20000}},
        {3, new Info() {Name = "掌门七爷", Desc = "惊天地泣鬼神般的优秀，丐帮出价80000两求购", Value = 80000}},
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
