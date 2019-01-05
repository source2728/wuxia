using System;
using Common;
using FairyGUI;
using Main;
using UnityEngine;

public class UIBuildingLevelUp : PanelWin<UI_BuildingLevelUp>
{
    protected int m_BuildingId = 0;

    public UIBuildingLevelUp()
    {
        MainBinder.BindAll();
        CommonBinder.BindAll();
        UIPackage.AddPackage("UI/Common");
        UIPackage.AddPackage("UI/Main");
    }

    protected override void OnInit()
    {
        base.OnInit();
        m_UI.m_BtnLevelUp.onClick.Add(OnClickLevelUp);
    }

    public override void OnUpdateData(params object[] d)
    {
        m_BuildingId = (int)d[0];
    }

    public override void OnRefresh()
    {
        var buildingProxy = AppFacade.getInstance().RetrieveProxy(BuildingProxy.Name) as BuildingProxy;
        var buildingInfo = buildingProxy.getBuildingInfo(m_BuildingId);
        m_UI.m_LabelCurLevel.text = buildingInfo.Level.ToString();
        m_UI.m_LabelCost.text = buildingInfo.getNextLevelGoldCost().ToString();
    }

    private void OnClickLevelUp(EventContext context)
    {
        BuildingFacade.getInstance().BuildingLevelUp(m_BuildingId);
    }
}
