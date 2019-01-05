using System.Collections.Generic;
using FairyGUI;

public class ViewStateMachine<T>
{
    protected T m_View;
    public Controller m_Controller;
    protected Dictionary<string, BaseViewState<T>> m_ViewStateMap = new Dictionary<string, BaseViewState<T>>();
    protected BaseViewState<T> m_CurrViewState;

    public ViewStateMachine(T view, Controller controller)
    {
        m_View = view;
        SetController(controller);
    }

    public void SetController(Controller controller)
    {
        m_Controller = controller;
        if (m_Controller != null)
        {
            m_Controller.onChanged.Set(OnViewStateChanged);
        }
    }

    public void AddViewState(string viewStateName, BaseViewState<T> viewState)
    {
        m_ViewStateMap.Add(viewStateName, viewState);
        viewState.OnInit(m_View);
    }

    private void OnViewStateChanged(EventContext context)
    {
        if (m_CurrViewState != null)
        {
            m_CurrViewState.OnExit();
        }

        var controller = context.sender as Controller;
        BaseViewState<T> viewState;
        if (m_ViewStateMap.TryGetValue(controller.selectedPage, out viewState))
        {
            viewState.OnEnter();
            m_CurrViewState = viewState;
        }
        else
        {
            m_CurrViewState = null;
        }
    }

    public void OnUpdate()
    {
        if (m_CurrViewState != null)
        {
            m_CurrViewState.OnUpdate();
        }
    }
}
