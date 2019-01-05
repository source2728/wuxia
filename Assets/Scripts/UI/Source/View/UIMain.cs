using FairyGUI;
using Main;
using Common;
using DG.Tweening;
using Pupil;
using UnityEngine;

public class UIMain : ViewWin<UI_UIMain>
{
    public UIMain()
    {
        CommonBinder.BindAll();
        MainBinder.BindAll();
        PupilBinder.BindAll();
        UIPackage.AddPackage("UI/Common");
        UIPackage.AddPackage("UI/Main");
        UIPackage.AddPackage("UI/Pupil");
    }

    public override void OnRefresh()
    {
        var userProxy = AppFacade.getInstance().RetrieveProxy(UserProxy.Name) as UserProxy;
        var userData = userProxy.getData();
        m_UI.m_TextGold.text = userData.Gold.ToString();
        m_UI.m_TestHonor.text = userData.Honor.ToString();

        m_UI.m_ViewState.selectedIndex = 0;
        m_UI.m_BuildingList.scrollPane.ScrollBottom(false);
    }

    protected override void OnInit()
    {
        base.OnInit();

        // 按钮绑定
        m_UI.m_Button1.onClick.Add(OnClickPupil);
        m_UI.m_Button2.onClick.Add(OnClickBag);
        m_UI.m_Button3.onClick.Add(OnClickMap);
        m_UI.m_Button4.onClick.Add(OnClickExplore);
        m_UI.m_Button5.onClick.Add(OnClickNotOpen);
        m_UI.m_BtnResetData.onClick.Add(OnClickResetData);

        // 建筑点击绑定
        m_UI.m_BuildingList.m_BtnZhengDian.onClick.AddCapture(OnClickZhengDian);
        m_UI.m_BuildingList.m_BtnWaiGongFang.onClick.AddCapture(OnClickWaiGongFang);
        m_UI.m_BuildingList.m_BtnShangPu.onClick.AddCapture(OnClickShangPu);

        var prefab = Resources.Load("Art_A/Effect/prefabs/pubu_shuihua");
        var go = Object.Instantiate(prefab) as GameObject;
        go.transform.localPosition = Vector3.zero;
        go.transform.localScale = new Vector3(100, 100, 1);
        m_UI.m_BuildingList.m_Scene.m_Splash1.SetNativeObject(new GoWrapper(go));

        go = Object.Instantiate(prefab) as GameObject;
        go.transform.localPosition = Vector3.zero;
        go.transform.localScale = new Vector3(100, 100, 1);
        m_UI.m_BuildingList.m_Scene.m_Splash2.SetNativeObject(new GoWrapper(go));

        var sequence = DOTween.Sequence();
        sequence.AppendInterval(3);
        sequence.AppendCallback(() => { m_UI.m_BuildingList.m_Scene.GetTransition("t1").Play(); });
        sequence.SetLoops(-1);
    }

    private void OnClickMap(EventContext context)
    {
        WinCenter.inst.TransView<UIAdventureView>();
    }

    private void OnClickBag(EventContext context)
    {
        WinCenter.inst.TransView<UIBagView>();
    }

    private void OnClickResetData(EventContext context)
    {
        AppFacade.getInstance().DataReset();
    }

    protected void OnClickPupil()
    {
        WinCenter.inst.TransView<UIPupilListView>();
    }

    private void OnClickZhengDian(EventContext context)
    {
        WinCenter.inst.ShowPanel<UIBuildingLevelUp>((int)EBuilding.ZhengDian);
    }

    private void OnClickWaiGongFang(EventContext context)
    {
        OnClickBuilding(EBuilding.WaiGongFang);
    }

    private void OnClickShangPu(EventContext context)
    {
        OnClickBuilding(EBuilding.ShangPu);
    }

    protected void OnClickExplore()
    {
        WinCenter.inst.TransView<UIExploreView>();
    }

    protected void OnClickTestGame1()
    {
        WinCenter.inst.TransView<UISmallGame1>();
    }

    protected void OnClickBuilding(EBuilding buildingId)
    {
        var buildingProxy = AppFacade.getInstance().RetrieveProxy(BuildingProxy.Name) as BuildingProxy;
        var buildingInfo = buildingProxy.getBuildingInfo((int)buildingId);
        if (buildingInfo != null)
        {
            if (buildingInfo.IsLock)
            {
                WinCenter.inst.ShowPanel<UIBuildingOpen>((int)buildingId);
            }
            else
            {
                WinCenter.inst.TransView<UIWaiGongFang>();
            }
        }
        else
        {
            WinCenter.inst.ShowTips("功能未开放");
        }
    }

    private void OnClickNotOpen(EventContext context)
    {
        WinCenter.inst.ShowTips("功能未开放");
    }
}
