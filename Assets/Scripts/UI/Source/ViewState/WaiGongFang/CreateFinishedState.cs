using System.Diagnostics;
using Common;
using FairyGUI;
using SkillCreate;

public class CreateFinishedState : BaseViewState<UIWaiGongFang>
{
    protected UI_WaiGongFang m_UI;

    public override void OnInit(UIWaiGongFang view)
    {
        base.OnInit(view);
        m_UI = view.m_UI;
        m_UI.m_BtnCreateFinish.onClick.Set(OnCreateFinish);
    }

    public override void OnEnter()
    {
        m_View.RefreshProgress();
        m_UI.m_LabelBasePower.SetValue(m_View.Data.BasePower);
        m_UI.m_LabelSkillPower.SetValue(m_View.Data.SkillPower);
        m_UI.m_LabelValue.SetValue(m_View.Data.Value);
        m_UI.m_LabelDiff.SetValue(m_View.Data.Diff);

        var pupilDeploy = PupilDeploy.GetInfo(m_View.Data.PupilId);
        m_UI.m_LabelCreatorName.SetText(pupilDeploy.Name);
        m_UI.m_IconCreator.icon = UIUtil.GetPupilHeadUrl(pupilDeploy.Sex);

        var createDeploy = UniqueSkillCreateDeploy.GetInfo(m_View.Data.SkillType, m_View.Data.SkillId).Value;
        (m_UI.m_IconUniqueSkill as UI_GoodsSmallIcon).m_State.selectedIndex = 1;
        m_UI.m_IconUniqueSkill.icon = UIUtil.GetUniqueSkillBookUrl(createDeploy.SkillEffectId);

        m_UI.m_LabelNameInput.text = "";
        m_View.OnRefreshPupilBody();
        m_UI.m_IconCreator.icon = UIUtil.GetPupilHeadUrl(pupilDeploy.Sex);
    }

    private void OnCreateFinish(EventContext context)
    {
        if (m_UI.m_LabelNameInput.text == "")
        {
            WinCenter.inst.ShowTips("名字不能为空！");
            return;
        }
        
        SkillCreateFacade.getInstance().CreateSkillFinish(m_View.Data, m_UI.m_LabelNameInput.text);
    }
}
