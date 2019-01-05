using Boo.Lang;
using UnityEngine;

public class FightController : MonoBehaviour
{
    public enum ETeamType
    {
        LeftSide,
        RightSide,
    }

    public delegate void FightFinishDelegate(Vector2 point, bool isWin);
    public FightFinishDelegate OnFightFinish = new FightFinishDelegate(DelegateFunction);
    public static void DelegateFunction(Vector2 point, bool isWin) { }

    public UIFightView FightView { get; set; }
    protected List<TeamController> m_TeamList = new List<TeamController>(2);
    protected Vector2 m_FightTilePoint;
    protected StateMachine<FightController> m_StateMachine = new StateMachine<FightController>();
    public bool IsWin { get; set; }

    protected int m_EnemyId;

    public List<TeamController> GetTeamList()
    {
        return m_TeamList;
    }

    public void SetResult(bool isWin)
    {
        IsWin = isWin;
    }

    public void GameOver()
    {
        OnFightFinish(m_FightTilePoint, IsWin);
        AudioManager.inst.PlayBgAudio("Adventure");
    }

    void Start()
    {
        m_StateMachine.OnInit(this, IdleState.Inst);
        m_StateMachine.OnStart();
    }

    void Update()
    {
        m_StateMachine.OnUpdate();        
    }

    public void ChangeState(BaseState<FightController> state)
    {
        m_StateMachine.ChangeState(state);
    }

    public void StartFight(Vector2 fightTilePoint, int enemyId)
    {
        m_EnemyId = enemyId;
        m_TeamList.Clear();
        m_FightTilePoint = fightTilePoint;
        AddTeam(0, ETeamType.LeftSide);
        AddTeam(1, ETeamType.RightSide);

        FightView = WinCenter.inst.TransView<UIFightView>(enemyId);
        foreach (var teamController in m_TeamList)
        {
            foreach (var characterController in teamController.CharacterList)
            {
                if (teamController.TeamType == ETeamType.LeftSide)
                {
                    characterController.InitView(FightView.AddLeft(), ETeamType.LeftSide, AdventureProxy.instance.GetData().PupilId);
                }
                else if (teamController.TeamType == ETeamType.RightSide)
                {
                    characterController.InitView(FightView.AddRight(), ETeamType.RightSide, enemyId);
                }
            }
        }

        m_StateMachine.ChangeState(FightPrepareState.Inst);
        AudioManager.inst.PlayBgAudio("Fight");
    }

    protected void AddTeam(int id, ETeamType type)
    {
        var team = new TeamController();
        team.TeamType = type;
        m_TeamList.Add(team);

        if (type == ETeamType.LeftSide)
        {
            var pupilId = AdventureProxy.instance.GetData().PupilId;
            var pupilInfo = PupilProxy.instance.getPupilInfo(pupilId);
            var wuxue = pupilInfo.GetEquipingWuXue();

            var character = team.AddCharacter(1, pupilId);
            character.TeamType = type;
            character.InitHp(200, 200);
            character.SkillId = wuxue != null ? wuxue.Id : 0;

            var normalAttack = new NormalAttack();
            normalAttack.AttackCount = 1;
            normalAttack.AttackHurt = 20;
            normalAttack.AttackTarget = null;
            character.InitNormalAttack(normalAttack);

            var skillAttack = new SkillAttack();
            skillAttack.AttackCount = 4;
            skillAttack.AttackHurt = 10;
            skillAttack.AttackTarget = null;
            skillAttack.SkillId = character.SkillId;
            character.InitSkillAttack(skillAttack);
        }
        else
        {
            var character = team.AddCharacter(2, m_EnemyId);
            character.TeamType = type;
            character.InitHp(200, 200);
            character.SkillId = EnemyDeploy.GetInfo(m_EnemyId).SkillEffectId;

            var normalAttack = new NormalAttack();
            normalAttack.AttackCount = 1;
            normalAttack.AttackHurt = 10;
            normalAttack.AttackTarget = null;
            character.InitNormalAttack(normalAttack);

            var skillAttack = new SkillAttack();
            skillAttack.AttackCount = 4;
            skillAttack.AttackHurt = 5;
            skillAttack.AttackTarget = null;
            skillAttack.SkillId = character.SkillId;
            character.InitSkillAttack(skillAttack);
        }
    }

    public CharacterController GetEnemyCharacter(CharacterController character)
    {
        foreach (var teamController in m_TeamList)
        {
            if (teamController.TeamType != character.TeamType)
            {
                return teamController.CharacterList[0];
            }
        }

        return null;
    }
}