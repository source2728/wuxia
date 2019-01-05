using System.Collections.Generic;
using System.Linq;

public class ExplorePlaceDeploy
{
    public struct Info
    {
        public string Name;
        public int Level;
        public int Cost;
        public int Combat;
        public ESex Sex;
        public int NeiGong;
        public int WaiGong;
    }

    public static Dictionary<int, Info> Datas = new Dictionary<int, Info>()
    {
        {1, new Info() {Name = "桃花岛", Level = 10, Cost = 1000, Combat = 10000, Sex = ESex.Woman, NeiGong = 100, WaiGong = 100}},
        {2, new Info() {Name = "滕王阁", Level = 20, Cost = 2000, Combat = 20000, Sex = ESex.Man, NeiGong = 200, WaiGong = 200}},
        {3, new Info() {Name = "燕子坞", Level = 30, Cost = 3000, Combat = 30000, Sex = ESex.Woman, NeiGong = 300, WaiGong = 300}},
        {4, new Info() {Name = "缥缈峰", Level = 40, Cost = 4000, Combat = 40000, Sex = ESex.Man, NeiGong = 400, WaiGong = 400}},
        {5, new Info() {Name = "西域边塞", Level = 50, Cost = 5000, Combat = 50000, Sex = ESex.Woman, NeiGong = 500, WaiGong = 500}},
        {6, new Info() {Name = "天山天池", Level = 60, Cost = 6000, Combat = 60000, Sex = ESex.Man, NeiGong = 600, WaiGong = 600}},
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
