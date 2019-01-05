using UnityEngine;
using static FightController;

public class FightingState : BaseState<FightController>
{
    protected static FightingState _Inst;
    public static FightingState Inst
    {
        get
        {
            if (_Inst == null)
            {
                _Inst = new FightingState();
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

        var dt = Time.deltaTime;
        var teamList = agent.GetTeamList();
        foreach (var teamController in teamList)
        {
            if (teamController.IsGameOver())
            {
                agent.SetResult(teamController.TeamType != ETeamType.LeftSide);
                agent.ChangeState(FightFinishState.Inst);
                break;
            }
            else
            {
                foreach (var characterController in teamController.CharacterList)
                {
                    if (!characterController.IsAttacking)
                    {
                        characterController.UpdateAttackCd(dt);
                        if (characterController.CanAttack())
                        {
                            characterController.StartAttack(agent);
                        }
                    }
                }
            }
        }
    }
}
