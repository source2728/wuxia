using Common;
using Explore;
using FairyGUI;

public class UIExploreSuccessPanel : PanelWin<UI_ExploreSuccessPanel>
{
    protected ExploreData m_ExploreData;

    public UIExploreSuccessPanel()
    {
        CommonBinder.BindAll();
        ExploreBinder.BindAll();
        UIPackage.AddPackage("UI/Common");
        UIPackage.AddPackage("UI/Explore");
    }

    public override void OnUpdateData(params object[] datas)
    {
        m_ExploreData = datas[0] as ExploreData;
    }

    public override void OnRefresh()
    {
        var placeDeploy = ExplorePlaceDeploy.GetInfo(m_ExploreData.PlaceId);
        m_UI.m_LabelPlaceName.SetText(placeDeploy.Name);

        m_UI.m_IconReward1.icon = UIUtil.GetGoodsUrl(EGoodsType.XinFa, 1);
        m_UI.m_IconReward1.title = "";
        m_UI.m_IconReward2.icon = UIUtil.GetGoodsUrl(EGoodsType.CanBen, 1);
        m_UI.m_IconReward2.title = "";
        m_UI.m_IconReward3.icon = UIUtil.GetGoodsUrl(EGoodsType.HuoBi, 1);
        m_UI.m_IconReward3.title = "3000";
    }

    protected override void OnInit()
    {
        base.OnInit();
    }
}
