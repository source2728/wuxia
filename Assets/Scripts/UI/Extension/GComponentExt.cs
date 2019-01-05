using Common;
using FairyGUI;

public static class GComponentExt
{
    public static UI_StarLevelBig AsStarLevelBig(this GComponent component)
    {
        return component as UI_StarLevelBig;
    }

    public static UI_StarLevel AsStarLevel(this GComponent component)
    {
        return component as UI_StarLevel;
    }
}
