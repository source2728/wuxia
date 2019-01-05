public class IdleState : BaseState<FightController>
{
    protected static IdleState _Inst;
    public static IdleState Inst
    {
        get
        {
            if (_Inst == null)
            {
                _Inst = new IdleState();
            }
            return _Inst;
        }
    }

    public override void OnEnter(FightController agent)
    {
        base.OnEnter(agent);
    }

    public override void OnExit(FightController agent)
    {
        base.OnExit(agent);
    }

    public override void OnUpdate(FightController agent)
    {
        base.OnUpdate(agent);
    }
}
