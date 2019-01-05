using SkillCreate;

public class CreatingBeforeChokeState : BaseViewState<UIWaiGongFang>
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
        m_UI.m_Progress.TweenValue(m_View.Data.GetChokingProgress(), 
            m_View.Data.ChokeStartTime - TimeUtil.CurrentTime());
        m_View.OnRefreshPupilBody();
    }
}
