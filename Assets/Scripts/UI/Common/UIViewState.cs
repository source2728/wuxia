using FairyGUI;

public class UIViewState<T> : BaseViewState<StateViewWin<T>> where T : GComponent
{
    protected T m_UI;

    public override void OnInit(StateViewWin<T> view)
    {
        base.OnInit(view);
        m_UI = view.m_UI;
    }
}
