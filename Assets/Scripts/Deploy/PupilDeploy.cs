using System.Collections.Generic;

public class PupilDeploy
{
    public struct Info
    {
        public string Name;
        public ESex Sex;
        public int Quality;
        public int StarLevel;
        public PupilAttr BaseAttr;
        public PupilAttr AttrUpPerLevel;
        public string Dese;
    }

    public static Dictionary<int, Info> Datas = new Dictionary<int, Info>()
    {
        {1, new Info() {Name = "东方姑娘", Sex = ESex.Woman, Quality = 1, StarLevel = 3,
            BaseAttr = new PupilAttr(){WuXing = 201, ZiZhi = 100, WaiGong = 200, NeiGong = 200, ShenFa = 1000, ShengMing = 1000, ZhenQi = 100, GongJi = 200, FangYu = 200, MingZhong = 100, ShanBi = 50, BaoJi = 20, KangBao = 10},
            AttrUpPerLevel = new PupilAttr(){WuXing = 5, ZiZhi = 10, WaiGong = 10, NeiGong = 10, ShenFa = 10, ShengMing = 100, ZhenQi = 5, GongJi = 10, FangYu = 10, MingZhong = 5, ShanBi = 5, BaoJi = 1, KangBao = 1},
            Dese = "东方姑娘是一个很牛逼的弟子"
        }},
        {2, new Info() {Name = "龙女姑姑", Sex = ESex.Woman, Quality = 1, StarLevel = 3,
            BaseAttr = new PupilAttr(){WuXing = 202, ZiZhi = 100, WaiGong = 200, NeiGong = 200, ShenFa = 1000, ShengMing = 1000, ZhenQi = 100, GongJi = 200, FangYu = 200, MingZhong = 100, ShanBi = 50, BaoJi = 20, KangBao = 10},
            AttrUpPerLevel = new PupilAttr(){WuXing = 5, ZiZhi = 10, WaiGong = 10, NeiGong = 10, ShenFa = 10, ShengMing = 100, ZhenQi = 5, GongJi = 10, FangYu = 10, MingZhong = 5, ShanBi = 5, BaoJi = 1, KangBao = 1},
            Dese = "龙女姑姑是一个很牛逼的弟子"
        }},
        {3, new Info() {Name = "令狐大侠", Sex = ESex.Man, Quality = 1, StarLevel = 3,
            BaseAttr = new PupilAttr(){WuXing = 203, ZiZhi = 100, WaiGong = 200, NeiGong = 200, ShenFa = 1000, ShengMing = 1000, ZhenQi = 100, GongJi = 200, FangYu = 200, MingZhong = 100, ShanBi = 50, BaoJi = 20, KangBao = 10},
            AttrUpPerLevel = new PupilAttr(){WuXing = 5, ZiZhi = 10, WaiGong = 10, NeiGong = 10, ShenFa = 10, ShengMing = 100, ZhenQi = 5, GongJi = 10, FangYu = 10, MingZhong = 5, ShanBi = 5, BaoJi = 1, KangBao = 1},
            Dese = "令狐大侠是一个很牛逼的弟子"
        }},
        {4, new Info() {Name = "神雕大侠", Sex = ESex.Man, Quality = 1, StarLevel = 3,
            BaseAttr = new PupilAttr(){WuXing = 204, ZiZhi = 100, WaiGong = 200, NeiGong = 200, ShenFa = 1000, ShengMing = 1000, ZhenQi = 100, GongJi = 200, FangYu = 200, MingZhong = 100, ShanBi = 50, BaoJi = 20, KangBao = 10},
            AttrUpPerLevel = new PupilAttr(){WuXing = 5, ZiZhi = 10, WaiGong = 10, NeiGong = 10, ShenFa = 10, ShengMing = 100, ZhenQi = 5, GongJi = 10, FangYu = 10, MingZhong = 5, ShanBi = 5, BaoJi = 1, KangBao = 1},
            Dese = "神雕大侠是一个很牛逼的弟子"
        }},
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
