using Common;
using FairyGUI;

public static class GLabelExt
{
    public static void SetDiff(this GLabel label, int diff)
    {
        var labelDiff = label as UI_LabelDiff;
        labelDiff.m_Value.selectedIndex = diff;
    }
    public static void SetDiff(this GLabel label, EDiff diff)
    {
        var labelDiff = label as UI_LabelDiff;
        labelDiff.m_Value.selectedIndex = (int)diff;
    }

    public static void SetFitness(this GLabel label, EFit fit)
    {
        var labelFit = label as UI_LabelFitness;
        labelFit.m_Value.selectedIndex = (int)fit;
    }
    public static void SetFitness(this GLabel label, int fitValue)
    {
        SetFitness(label, Define.ValueToFit(fitValue));
    }

    public static void SetText(this GLabel label, int data)
    {
        label.text = data.ToString();
    }

    public static void SetText(this GLabel label, string data)
    {
        label.text = data;
    }
}
