using System;
using FairyGUI;
using Main;
using UnityEngine;

public class UIBuildingOpen : PanelWin<UI_BuildingOpen>
{
    protected int m_BuildingId = 0;

    public UIBuildingOpen()
    {
        UIPackage.AddPackage("UI/Common");
        UIPackage.AddPackage("UI/Main");
        MainBinder.BindAll();
    }

    protected override void OnInit()
    {
        base.OnInit();
        m_UI.m_BtnUnlock.onClick.Add(OnClickUnlock);
    }

    public override void OnUpdateData(params object[] d)
    {
        m_BuildingId = (int)d[0];
    }

    public override void OnRefresh()
    {
        var buildingProxy = AppFacade.getInstance().RetrieveProxy(BuildingProxy.Name) as BuildingProxy;
        var buildingInfo = buildingProxy.getBuildingInfo(m_BuildingId);
        m_UI.m_LabelCost.text = buildingInfo.getNextLevelGoldCost().ToString();
    }

    private void OnClickUnlock(EventContext context)
    {
        BuildingFacade.getInstance().BuildingUnlock(m_BuildingId);
        Hide();
    }
}
