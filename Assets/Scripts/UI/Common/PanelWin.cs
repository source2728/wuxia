using System.Reflection;
using Common;
using FairyGUI;

public class PanelWin<T> : BaseWindow where T : GComponent
{
    protected T m_UI;

    protected override void OnInit()
    {
        var targetType = typeof(T);
        const BindingFlags f = BindingFlags.Static | BindingFlags.Public | BindingFlags.IgnoreCase;
        var mi = targetType.GetMethod("CreateInstance", f);
        contentPane = mi.Invoke(null, null) as GComponent;
        contentPane.sortingOrder = 1;
        Center();

        m_UI = this.contentPane as T;

        var layer = UI_ModalLayer.CreateInstance();
        AddChild(layer);
        layer.Center();
        layer.onClick.AddCapture((context =>
        {
            Hide();
        }));
    }
}
