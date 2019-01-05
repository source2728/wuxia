using Adventure;
using FairyGUI;
using Common;

public class UIMapView : ViewWin<UI_MapView>
{
    protected int m_PupilId = 0;

    public UIMapView()
    {
        CommonBinder.BindAll();
        AdventureBinder.BindAll();
        UIPackage.AddPackage("UI/Common");
        UIPackage.AddPackage("UI/Adventure");
    }

    public override void OnUpdateData(params object[] datas)
    {
        m_PupilId = (int) datas[0];
    }

    public override void OnRefresh()
    {
        var userInfo = UserProxy.instance.getData();
        var info = PupilProxy.instance.getPupilInfo(m_PupilId);
        var deploy = PupilDeploy.GetInfo(m_PupilId);

        m_UI.m_TopInfo.m_LabelLevel.SetValue(info.Level);
        m_UI.m_TopInfo.m_LabelExp.SetCurAndMax(info.CurExp, info.MaxExp);
        m_UI.m_TopInfo.m_LabelName.SetText(deploy.Name);
        m_UI.m_TopInfo.m_LabelHonor.SetText(userInfo.Honor);
        m_UI.m_TopInfo.m_LabelGold.SetText(userInfo.Gold);
        m_UI.m_IconHead.icon = UIUtil.GetPupilHeadUrl(deploy.Sex);
    }

    protected override void OnInit()
    {
        base.OnInit();
        m_UI.m_BtnBack.onClick.AddCapture(OnClickBack);
    }

    private void OnClickBack(EventContext context)
    {
        WinCenter.inst.ShowPanel<UISummaryInfoPanel>();
    }
}