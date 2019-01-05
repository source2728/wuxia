using System.Collections.Generic;

public class DropDeploy
{
    public struct DropInfo
    {
        public int RandWeight;
        public EGoodsType GoodsType;
        public int GoodsId;
    }
    public struct Info
    {
        public List<DropInfo> DropInfos;
    }

    public static Dictionary<int, Info> Datas = new Dictionary<int, Info>()
    {
        // 敌人掉落
        {1, new Info(){ DropInfos = new List<DropInfo>()
            {
                new DropInfo(){RandWeight = 10, GoodsType = EGoodsType.DaoJu, GoodsId = 1},
                new DropInfo(){RandWeight = 10, GoodsType = EGoodsType.XinFa, GoodsId = 1},
                new DropInfo(){RandWeight = 10, GoodsType = EGoodsType.CanBen, GoodsId = 1},
            }
        }},
        // 宝箱掉落
        {2, new Info(){ DropInfos = new List<DropInfo>()
            {
                new DropInfo(){RandWeight = 10, GoodsType = EGoodsType.DaoJu, GoodsId = 2},
                new DropInfo(){RandWeight = 10, GoodsType = EGoodsType.XinFa, GoodsId = 2},
                new DropInfo(){RandWeight = 10, GoodsType = EGoodsType.CanBen, GoodsId = 2},
            }
        }},
        // NPC掉落
        {3, new Info(){ DropInfos = new List<DropInfo>()
            {
                new DropInfo(){RandWeight = 10, GoodsType = EGoodsType.DaoJu, GoodsId = 3},
                new DropInfo(){RandWeight = 10, GoodsType = EGoodsType.XinFa, GoodsId = 3},
                new DropInfo(){RandWeight = 10, GoodsType = EGoodsType.CanBen, GoodsId = 3},
            }
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
