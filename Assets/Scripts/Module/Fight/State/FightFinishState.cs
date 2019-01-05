using DG.Tweening;
using UnityEngine;

public class FightFinishState : BaseState<FightController>
{
    protected static FightFinishState _Inst;
    public static FightFinishState Inst
    {
        get
        {
            if (_Inst == null)
            {
                _Inst = new FightFinishState();
            }
            return _Inst;
        }
    }

    public bool IsAniFinished = false;

    public override void OnEnter(FightController agent)
    {
        base.OnEnter(agent);
        IsAniFinished = false;
        agent.FightView.m_UI.m_FightWin.visible = false;
        agent.FightView.m_UI.m_FightLose.visible = false;

        AudioManager.inst.StopBgAudio();
        if (agent.IsWin)
        {
            AudioManager.inst.PlayAudioEffect("FightWin");
        }
        else
        {
            AudioManager.inst.PlayAudioEffect("FightLose");
        }

        var sequence = DOTween.Sequence();
        sequence.AppendInterval(0.5f)
            .AppendCallback((() =>
            {
                if (agent.IsWin)
                {
                    agent.FightView.m_UI.m_FightWin.visible = true;
                    agent.FightView.m_UI.m_FightWin.GetTransition("t0").Play();
                }
                else
                {
                    agent.FightView.m_UI.m_FightLose.visible = true;
                    agent.FightView.m_UI.m_FightLose.GetTransition("t0").Play();
                }
            }))
            .AppendInterval(1.5f)
            .AppendCallback((() => { IsAniFinished = true; }));
    }

    public override void OnExit(FightController agent)
    {
        base.OnExit(agent);
        Debug.Log("FightController Fight Finish");
        agent.GameOver();
        WinCenter.inst.ViewBack();
    }

    public override void OnUpdate(FightController agent)
    {
        base.OnUpdate(agent);
        if (IsAniFinished)
        {
            agent.ChangeState(IdleState.Inst);
        }
    }
}
