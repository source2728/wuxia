using Common;
using FairyGUI;
using SkillCreate;

public static class CustomExt
{
    public static void SetLevel(this UI_StarLevelBig starLevel, int level)
    {
        starLevel.m_Level.selectedIndex = level;
    }

    public static void SetLevel(this UI_StarLevel starLevel, int level)
    {
        starLevel.m_Level.selectedIndex = level;
    }

    public static void SetValue(this UI_LabelAttr label, int value)
    {
        label.m_LabelValue.text = value.ToString();
    }
}
