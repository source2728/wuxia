using FairyGUI;
using System;

public class StateViewWin<T> : ViewWin<T> where T : GComponent
{
    protected ViewStateMachine<StateViewWin<T>> m_ViewStateMachine;

    protected override void OnUpdate()
    {
        base.OnUpdate();
        m_ViewStateMachine.OnUpdate();
    }

    protected override void OnInit()
    {
        base.OnInit();
        m_ViewStateMachine = new ViewStateMachine<StateViewWin<T>>(this, null);
    }

    public void ChangeViewState<E>(E state)
    {
        m_ViewStateMachine.m_Controller.selectedPage = Enum.GetName(typeof(E), state);
    }

    protected void AddViewState<E, S>(E state, S viewState) where S : BaseViewState<StateViewWin<T>>
    {
        m_ViewStateMachine.AddViewState(Enum.GetName(typeof(E), state), viewState);
    }

    protected void SetStateController(Controller controller)
    {
        m_ViewStateMachine.SetController(controller);
    }
}
