using SkillCreate;

public class CreatingAfterEventState : BaseViewState<UIWaiGongFang>
{
    protected UI_WaiGongFang m_UI;

    public override void OnInit(UIWaiGongFang view)
    {
        base.OnInit(view);
        m_UI = view.m_UI;
    }

    public override void OnEnter()
    {
        m_View.RefreshProgress();
        m_UI.m_Progress.TweenValue(1, m_View.Data.FinishTime - TimeUtil.CurrentTime());
        m_View.OnRefreshPupilBody();
    }
}
