using SkillCreate;

public class CreatingBeforeEventState : BaseViewState<UIWaiGongFang>
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

        m_UI.m_Progress.TweenValue(m_View.Data.GetEventingProgress(), 
            m_View.Data.EventStartTime - TimeUtil.CurrentTime());
        m_View.OnRefreshPupilBody();
    }
}
