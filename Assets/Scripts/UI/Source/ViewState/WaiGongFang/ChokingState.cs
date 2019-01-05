using FairyGUI;
using SkillCreate;

public class ChokingState : BaseViewState<UIWaiGongFang>
{
    protected UI_WaiGongFang m_UI;

    public override void OnInit(UIWaiGongFang view)
    {
        base.OnInit(view);
        m_UI = view.m_UI;
        m_UI.m_BtnCreateAgain.onClick.Set(OnClickCreateAgain);   // 继续研读
        m_UI.m_BtnGoPlace.onClick.Set(OnClickGoPlace);           // 外出领悟
    }

    public override void OnEnter()
    {
        m_View.RefreshProgress();
        m_View.OnRefreshPupilBody();
    }

    /// <summary>
    /// 外出领悟
    /// </summary>
    /// <param name="context"></param>
    private void OnClickGoPlace(EventContext context)
    {
        m_View.ChangeViewState(UIWaiGongFang.EViewState.SelectPlace);
    }

    /// <summary>
    /// 继续研读
    /// </summary>
    /// <param name="context"></param>
    private void OnClickCreateAgain(EventContext context)
    {
        SkillCreateFacade.getInstance().GiveUpEvent();
    }
}
