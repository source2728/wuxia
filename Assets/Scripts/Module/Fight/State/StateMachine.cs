public class StateMachine<T>
{
    protected BaseState<T> m_CurState;
    protected T m_Agent;

    public void OnInit(T agent, BaseState<T> firstState = null)
    {
        m_Agent = agent;
        m_CurState = firstState;
    }

    public void OnStart()
    {
        if (m_CurState != null)
        {
            m_CurState.OnEnter(m_Agent);
        }
    }

    public void ChangeState(BaseState<T> state)
    {
        if (m_CurState != null)
        {
            m_CurState.OnExit(m_Agent);
        }
        m_CurState = state;
        m_CurState.OnEnter(m_Agent);
    }

    public void OnUpdate()
    {
        if (m_CurState != null)
        {
            m_CurState.OnUpdate(m_Agent);
        }
    }
}
