using FairyGUI;

public class UIUtil
{
    public static string GetFitnessUrl(EFit fit)
    {
        return UIPackage.GetItemURL("Common", "Fitness_" + (int)fit);
    }
    public static string GetFitnessUrl(int fitValue)
    {
        return GetFitnessUrl(Define.ValueToFit(fitValue));
    }

    public static string GetPupilAttUrl(EAttrType type)
    {
        return UIPackage.GetItemURL("Common", "IconPupilAttr_" + (int)type);
    }

    public static string GetPupilHeadUrl(ESex sex)
    {
        return UIPackage.GetItemURL("Common", "IconPupilHead_" + (int)sex);
    }

    public static string GetPupilBodyUrl(ESex sex)
    {
        return UIPackage.GetItemURL("Common", "IconPupilBody_" + (int)sex);
    }

    public static string GetDiffUrl(EDiff diff)
    {
        return UIPackage.GetItemURL("Common", "Diff_" + (int)diff);
    }

    public static string GetGoodsUrl(EGoodsType type, int id)
    {
        switch (type)
        {
            case EGoodsType.DaoJu:
                return UIPackage.GetItemURL("Common", "IconGoods_" + id);

            case EGoodsType.XinFa:
                return UIPackage.GetItemURL("Common", "IconXinFa_" + id);

            case EGoodsType.CanBen:
                return UIPackage.GetItemURL("Common", "IconZhaoShi_" + id);

            case EGoodsType.WuXue:
                var info = UniqueSkillProxy.instance.GetData(id);
                return UIPackage.GetItemURL("Common", "IconUniqueSkillBook_" + info.SkillEffectId);

            case EGoodsType.HuoBi:
                return UIPackage.GetItemURL("Common", "IconHuoBi_" + id);
        }

        return "";
    }

    public static string GetUniqueSkillBookUrl(int id)
    {
        return UIPackage.GetItemURL("Common", "IconUniqueSkillBook_" + id);
    }

    public static string GetUniqueSkillEffectUrl(int id)
    {
        return UIPackage.GetItemURL("Common", "IconUniqueSkillEffect_" + id);
    }

    public static string GetBuyPlaceUrl(int id)
    {
        return UIPackage.GetItemURL("SkillCreate", "PlaceIcon_" + id);
    }

    public static string GetEnemyHeadUrl(int id)
    {
        return UIPackage.GetItemURL("Common", "IconEnemyHead_" + id);
    }
}
