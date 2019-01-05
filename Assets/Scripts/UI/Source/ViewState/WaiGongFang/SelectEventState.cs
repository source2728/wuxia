using FairyGUI;
using SkillCreate;

public class SelectEventState : BaseViewState<UIWaiGongFang>
{
    protected UI_WaiGongFang m_UI;

    public override void OnInit(UIWaiGongFang view)
    {
        base.OnInit(view);
        m_UI = view.m_UI;
        m_UI.m_BtnPowerUp.onClick.Set(OnClickPowerUp);           // 提升威力
        m_UI.m_BtnQualityUp.onClick.Set(OnClickQualityUp);       // 提升质量
    }

    public override void OnEnter()
    {
        m_View.RefreshProgress();
        m_View.OnRefreshPupilBody();
    }

    /// <summary>
    /// 提升质量
    /// </summary>
    /// <param name="context"></param>
    private void OnClickQualityUp(EventContext context)
    {
        WinCenter.inst.ShowPanel<UIAdventure2>(m_View.Data);
    }

    /// <summary>
    /// 提升威力
    /// </summary>
    /// <param name="context"></param>
    private void OnClickPowerUp(EventContext context)
    {
        WinCenter.inst.ShowPanel<UIAdventure1>(m_View.Data);
    }
}
