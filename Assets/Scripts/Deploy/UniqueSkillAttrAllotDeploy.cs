using System.Collections.Generic;

public class UniqueSkillAttrAllotDeploy
{
    public struct Info
    {
        public int SkillId;
        public PupilAttr Allot1;
        public PupilAttr Allot2;
    }

    public static Dictionary<int, Info> Datas = new Dictionary<int, Info>()
    {
        {1, new Info() {SkillId = 1,
            Allot1 = new PupilAttr(){WaiGong = 20, NeiGong = 70, ShenFa = 10},
            Allot2 = new PupilAttr(){GongJi = 20, FangYu = 40, MingZhong = 10, ShanBi = 10, BaoJi = 10, KangBao = 10}
        }},
        {2, new Info() {SkillId = 2,
            Allot1 = new PupilAttr(){WaiGong = 20, NeiGong = 70, ShenFa = 10},
            Allot2 = new PupilAttr(){GongJi = 40, FangYu = 20, MingZhong = 10, ShanBi = 10, BaoJi = 10, KangBao = 10}
        }},
        {3, new Info() {SkillId = 3,
            Allot1 = new PupilAttr(){WaiGong = 70, NeiGong = 20, ShenFa = 10},
            Allot2 = new PupilAttr(){GongJi = 20, FangYu = 40, MingZhong = 10, ShanBi = 10, BaoJi = 10, KangBao = 10}
        }},
        {4, new Info() {SkillId = 4,
            Allot1 = new PupilAttr(){WaiGong = 70, NeiGong = 20, ShenFa = 10},
            Allot2 = new PupilAttr(){GongJi = 40, FangYu = 20, MingZhong = 10, ShanBi = 10, BaoJi = 10, KangBao = 10}
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
