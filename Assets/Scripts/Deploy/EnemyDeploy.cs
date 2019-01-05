using System.Collections.Generic;

public class EnemyDeploy
{
    public struct Info
    {
        public string Name;
        public ESex Sex;
        public int Quality;
        public int Level;
        public int Combat;
        public int SkillEffectId;
        public PupilAttr BaseAttr;
        public string Dese;
        public string FightContent;
    }

    public static Dictionary<int, Info> Datas = new Dictionary<int, Info>()
    {
        {1, new Info() {Name = "剑神", Sex = ESex.Man, Quality = 1, Level = 5, Combat = 20000, SkillEffectId = 1,
            BaseAttr = new PupilAttr(){WuXing = 200, ZiZhi = 100, WaiGong = 200, NeiGong = 200, ShenFa = 1000, ShengMing = 1000, ZhenQi = 100, GongJi = 200, FangYu = 200, MingZhong = 100, ShanBi = 50, BaoJi = 20, KangBao = 10},
            Dese = "剑神是一个很牛逼的弟子", FightContent = "剑术的境界会不会是永无止境的？"
        }},
        {2, new Info() {Name = "剑圣", Sex = ESex.Man, Quality = 1, Level = 5, Combat = 20000, SkillEffectId = 2,
            BaseAttr = new PupilAttr(){WuXing = 200, ZiZhi = 100, WaiGong = 200, NeiGong = 200, ShenFa = 1000, ShengMing = 1000, ZhenQi = 100, GongJi = 200, FangYu = 200, MingZhong = 100, ShanBi = 50, BaoJi = 20, KangBao = 10},
            Dese = "剑圣是一个很牛逼的弟子", FightContent = "看我的双刀流……每次都可以把脸刮的很干净~"
        }},
        {3, new Info() {Name = "剑神迷妹", Sex = ESex.Woman, Quality = 1, Level = 4, Combat = 5000, SkillEffectId = 3,
            BaseAttr = new PupilAttr(){WuXing = 200, ZiZhi = 100, WaiGong = 200, NeiGong = 200, ShenFa = 1000, ShengMing = 1000, ZhenQi = 100, GongJi = 200, FangYu = 200, MingZhong = 100, ShanBi = 50, BaoJi = 20, KangBao = 10},
            Dese = "剑神迷妹是一个很牛逼的弟子", FightContent = "他什么都很好，只是他属于剑的"
        }},
        {4, new Info() {Name = "剑圣迷妹", Sex = ESex.Woman, Quality = 1, Level = 4, Combat = 5000, SkillEffectId = 4,
            BaseAttr = new PupilAttr(){WuXing = 200, ZiZhi = 100, WaiGong = 200, NeiGong = 200, ShenFa = 1000, ShengMing = 1000, ZhenQi = 100, GongJi = 200, FangYu = 200, MingZhong = 100, ShanBi = 50, BaoJi = 20, KangBao = 10},
            Dese = "剑圣迷妹是一个很牛逼的弟子", FightContent = "可惜他痴情的对象不是我，而是剑啊"
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
