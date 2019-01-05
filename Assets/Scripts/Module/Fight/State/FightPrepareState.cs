using System;
using DG.Tweening;

public class FightPrepareState : BaseState<FightController>
{
    protected static FightPrepareState _Inst;
    public static FightPrepareState Inst
    {
        get
        {
            if (_Inst == null)
            {
                _Inst = new FightPrepareState();
            }
            return _Inst;
        }
    }

    public bool IsAniFinished = false;

    public override void OnEnter(FightController agent)
    {
        base.OnEnter(agent);
        IsAniFinished = false;
        agent.FightView.m_UI.m_FightStart.visible = false;

        var sequence = DOTween.Sequence();
        sequence.AppendInterval(0.5f)
            .AppendCallback((() =>
            {
                agent.FightView.m_UI.m_FightStart.visible = true;
                agent.FightView.m_UI.m_FightStart.GetTransition("t0").Play();
            }))
            .AppendInterval(1.5f)
            .AppendCallback((() => { IsAniFinished = true; }));
    }

    public override void OnExit(FightController agent)
    {
        base.OnExit(agent);
        agent.FightView.m_UI.m_FightStart.visible = false;
    }

    public override void OnUpdate(FightController agent)
    {
        base.OnUpdate(agent);
        if (IsAniFinished)
        {
            agent.ChangeState(FightingState.Inst);
        }
    }
}
