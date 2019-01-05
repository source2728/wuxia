using FairyGUI;
using Main;
using Fight;

public class UIFightView : ViewWin<UI_FightView>
{
    protected int m_EnemyId = 0;
    public UIFightView()
    {
        UIPackage.AddPackage("UI/Common");
        UIPackage.AddPackage("UI/Fight");
        FightBinder.BindAll();
    }

    public override void OnUpdateData(params object[] datas)
    {
        m_EnemyId = (int) datas[0];
    }

    public override void OnRefresh()
    {
        m_UI.m_FightStart.visible = false;
        m_UI.m_FightWin.visible = false;
        m_UI.m_FightLose.visible = false;
        OnRefreshPupilInfo();
        OnRefreshEnemyInfo();
    }

    private void OnRefreshPupilInfo()
    {
        var pupilId = AdventureProxy.instance.GetData().PupilId;
        var pupilInfo = PupilProxy.instance.getPupilInfo(pupilId);
        var pupilDeploy = PupilDeploy.GetInfo(pupilId);
        var wuxue = pupilInfo.GetEquipingWuXue();

        m_UI.m_LeftCharacterInfo.m_LabelName.SetText(pupilDeploy.Name);
        m_UI.m_LeftCharacterInfo.m_LabelLevel.SetValue(pupilInfo.Level);
        m_UI.m_LeftCharacterInfo.m_LabelCombat.SetText(pupilInfo.GetCombat());
        if (wuxue != null)
        {
            m_UI.m_LeftSkillInfo.visible = true;
            var uniqueSkillInfo = UniqueSkillProxy.instance.GetData(wuxue.Id);
            var wuxueDeploy = SkillEffectDeploy.GetInfo(uniqueSkillInfo.Id);
            m_UI.m_LeftSkillInfo.m_LabelName.SetText(uniqueSkillInfo.Name);
            m_UI.m_LeftSkillInfo.m_LoaderIcon.url = UIUtil.GetUniqueSkillEffectUrl(uniqueSkillInfo.Id);
            m_UI.m_LabelLeftSkillName.SetText(uniqueSkillInfo.Name);
        }
        else
        {
            m_UI.m_LeftSkillInfo.visible = false;
        }
    }

    private void OnRefreshEnemyInfo()
    {
        var enemyDeploy = EnemyDeploy.GetInfo(m_EnemyId);

        m_UI.m_RightCharacterInfo.m_LabelName.SetText(enemyDeploy.Name);
        m_UI.m_RightCharacterInfo.m_LabelLevel.SetValue(enemyDeploy.Level);
        m_UI.m_RightCharacterInfo.m_LabelCombat.SetText(enemyDeploy.Combat);
        if (enemyDeploy.SkillEffectId > 0)
        {
            m_UI.m_RightSkillInfo.visible = true;
            var wuxueDeploy = SkillEffectDeploy.GetInfo(enemyDeploy.SkillEffectId);
            m_UI.m_RightSkillInfo.m_LabelName.SetText(wuxueDeploy.Name);
            m_UI.m_RightSkillInfo.m_LoaderIcon.url = UIUtil.GetUniqueSkillEffectUrl(enemyDeploy.SkillEffectId);
            m_UI.m_LabelRightSkillName.SetText(wuxueDeploy.Name);
        }
        else
        {
            m_UI.m_RightSkillInfo.visible = false;
        }
    }

    protected override void OnInit()
    {
        base.OnInit();
        m_UI.m_FightStart.visible = false;
        m_UI.m_FightWin.visible = false;
    }

    public UI_Character AddLeft()
    {
        m_UI.m_LoaderLeft.url = UI_Character.URL;
        return m_UI.m_LoaderLeft.component as UI_Character;
    }

    public UI_Character AddRight()
    {
        m_UI.m_LoaderRight.url = UI_Character.URL;
        return m_UI.m_LoaderRight.component as UI_Character;
    }
}
