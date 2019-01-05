public class Language
{
    protected static string[] QualityNames = {"空", "凡品", "珍品", "超品", "极品", "绝品"};
    public static string GetQuality(EGoodsQuality quality)
    {
        return QualityNames[(int) quality];
    }

    protected static string[] GoodsTypeNames = { "空", "绝学", "装备", "道具", "心法", "残本" };
    public static string GetGoodsTypeName(EGoodsType type)
    {
        return GoodsTypeNames[(int)type];
    }
}