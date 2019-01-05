using FairyGUI;
using Explore;
using Common;

public class UIExploreView : StateViewWin<UI_ExploreView>
{
    public enum EViewState
    {
        None,
        SelectPlace,
        PrepareExplore,
        Exploring,
        ExploreFinish,
    }

    public UIExploreView()
    {
        CommonBinder.BindAll();
        ExploreBinder.BindAll();
        UIPackage.AddPackage("UI/Common");
        UIPackage.AddPackage("UI/Explore");
    }

    public override void OnRefresh()
    {
        m_UI.m_ViewState.selectedIndex = 0;
        m_UI.m_BtnSelectLeft.m_ViewState.selectedIndex = 0;
        m_UI.m_BtnSelectRight.m_ViewState.selectedIndex = 0;

        var data = ExploreProxy.instance.GetData();
        if (data.IsFinished())
        {
            m_UI.data = data;
            ChangeViewState(EViewState.ExploreFinish);
        }
        else if (data.IsExploring())
        {
            m_UI.data = data;
            ChangeViewState(EViewState.Exploring);
        }
        else
        {
            m_UI.data = new ExploreData();
            ChangeViewState(EViewState.SelectPlace);
        }

        RefreshCond();
    }

    protected override void OnInit()
    {
        base.OnInit();
        SetStateController(m_UI.m_ViewState);
        AddViewState(EViewState.SelectPlace, new ViewState.ExploreView.SelectPlaceState());
        AddViewState(EViewState.PrepareExplore, new ViewState.ExploreView.PrepareExploreState());
        AddViewState(EViewState.Exploring, new ViewState.ExploreView.ExploringState());
        AddViewState(EViewState.ExploreFinish, new ViewState.ExploreView.ExploreFinishState());
        m_UI.m_BtnBack.onClick.Set(ViewBack);

        m_UI.m_IconReward1.icon = UIUtil.GetGoodsUrl(EGoodsType.XinFa, 1);
        m_UI.m_IconReward1.title = "";
        m_UI.m_IconReward2.icon = UIUtil.GetGoodsUrl(EGoodsType.CanBen, 1);
        m_UI.m_IconReward2.title = "";
        m_UI.m_IconReward3.icon = UIUtil.GetGoodsUrl(EGoodsType.HuoBi, 1);
        m_UI.m_IconReward3.title = "3000";
    }

    public void RefreshCond()
    {
        var data = m_UI.data as ExploreData;
        if (data.PlaceId <= 0)
        {
            m_UI.m_LabelSuccessRate.SetValue(0);
            return;
        }

        var placeDeploy = ExplorePlaceDeploy.GetInfo(data.PlaceId);

        int[] conds = new int[5] {0, 0, 0, 0, 0};

        var pupil1 = PupilProxy.instance.getPupilInfo(data.PupilId1);
        if (pupil1 != null)
        {
            var deploy = PupilDeploy.GetInfo(pupil1.DId);
            conds[0] += (pupil1.GetCombat() > placeDeploy.Combat) ? 1 : 0;
            conds[1] += (deploy.Sex == placeDeploy.Sex) ? 1 : 0;
            conds[2] += 1;
            conds[3] += (pupil1.GetAttr(EAttrType.NeiGong) > placeDeploy.NeiGong) ? 1 : 0;
            conds[4] += (pupil1.GetAttr(EAttrType.WaiGong) > placeDeploy.WaiGong) ? 1 : 0;
        }

        var pupil2 = PupilProxy.instance.getPupilInfo(data.PupilId2);
        if (pupil2 != null)
        {
            var deploy = PupilDeploy.GetInfo(pupil2.DId);
            conds[0] += (pupil2.GetCombat() > placeDeploy.Combat) ? 1 : 0;
            conds[1] += (deploy.Sex == placeDeploy.Sex) ? 1 : 0;
            conds[2] += 1;
            conds[3] += (pupil2.GetAttr(EAttrType.NeiGong) > placeDeploy.NeiGong) ? 1 : 0;
            conds[4] += (pupil2.GetAttr(EAttrType.WaiGong) > placeDeploy.WaiGong) ? 1 : 0;
        }

        m_UI.m_Combat.selectedIndex = (conds[0] > 0) ? 1 : 0;
        m_UI.m_Sex.selectedIndex = (conds[1] > 0) ? 1 : 0;
        m_UI.m_WuXue.selectedIndex = (conds[2] > 0) ? 1 : 0;
        m_UI.m_NeiGong.selectedIndex = (conds[3] > 0) ? 1 : 0;
        m_UI.m_WaiGong.selectedIndex = (conds[4] > 0) ? 1 : 0;

        var rate = 0;
        for (int i = 0; i < 5; i++)
        {
            rate += conds[i];
        }
        rate *= 10;
        m_UI.m_LabelSuccessRate.SetValue(rate);
    }
}
