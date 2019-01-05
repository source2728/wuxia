using System.Collections.Generic;

public class SkillEffectDeploy
{
    public struct Info
    {
        public string Name;
        public string Desc;
    }

    public static Dictionary<int, Info> Datas = new Dictionary<int, Info>()
    {
        {1, new Info() {Name = "太极剑阵", Desc = "在敌方头顶召唤出八卦阵，并从八卦阵中飞出（1-9）道剑气，每道剑气造成内功x50%的伤害。"}},
        {2, new Info() {Name = "太极刀阵", Desc = "在敌方脚底召唤出八卦阵，并从八卦阵中心向外飞出（1-9）道刀气，没道刀气造成内功x50%的伤害。"}},
        {3, new Info() {Name = "纯阳剑气", Desc = "向敌方放出（1-9）道剑气，每道剑气造成内功x100%的伤害。"}},
        {4, new Info() {Name = "回旋刀气", Desc = "向敌方靠近，并原地旋转发出刀气，对敌方造成（1-9）次伤害，每次造成内功x100%的伤害。"}},
        {5, new Info() {Name = "大剑砸下", Desc = "提升（10%-90%）的暴击，并向敌人放出一道大型剑气，对敌方造成1次外功伤害。"}},
        {6, new Info() {Name = "大刀砸下", Desc = "提升（10%-90%）的暴击，向敌人放出一道大型刀气，对敌方造成1次外功伤害。"}},
        {7, new Info() {Name = "连刺剑法", Desc = "向敌方靠近，对敌人连续攻击（1-9）次，每次造成外功x50%的伤害，可暴击。"}},
        {8, new Info() {Name = "连砍刀法", Desc = "向敌方靠近，对敌人连续砍击（1-9）次，每次造成外功x50%的伤害，可暴击。"}},
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
