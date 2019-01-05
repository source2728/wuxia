using System.Reflection;
using FairyGUI;
using Main;

public class ViewWin<T> : BaseWindow where T : GComponent
{
    public T m_UI;

    protected override void OnInit()
    {
        var targetType = typeof(T);
        const BindingFlags f = BindingFlags.Static | BindingFlags.Public | BindingFlags.IgnoreCase;
        var mi = targetType.GetMethod("CreateInstance", f);
        contentPane = mi.Invoke(null, null) as GComponent;
        contentPane.sortingOrder = 1;
        Center();

        m_UI = this.contentPane as T;
    }

    protected void ViewBack(EventContext context)
    {
        WinCenter.inst.ViewBack();
    }
}
