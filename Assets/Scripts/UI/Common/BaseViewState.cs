public class BaseViewState<T>
{
    protected T m_View;

    public virtual void OnInit(T view)
    {
        m_View = view;
    }

    public virtual void OnEnter()
    {

    }

    public virtual void OnUpdate()
    {

    }

    public virtual void OnExit()
    {

    }
}
