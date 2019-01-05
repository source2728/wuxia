using System;
using Adventure;
using Common;
using FairyGUI;
using SkillCreate;
using UnityEngine;

public class UIEnemyInfoPanel : PanelWin<UI_EnemyInfoPanel>
{
    protected Vector2 m_TilePoint;
    protected int m_EnemyId;

    public UIEnemyInfoPanel()
    {
        CommonBinder.BindAll();
        AdventureBinder.BindAll();
        UIPackage.AddPackage("UI/Common");
        UIPackage.AddPackage("UI/Adventure");
    }

    public override void OnUpdateData(params object[] d)
    {
        m_TilePoint = (Vector2)d[0];
        m_EnemyId = (int) d[1];
    }

    public override void OnRefresh()
    {
        var deploy = EnemyDeploy.GetInfo(m_EnemyId);
        m_UI.m_LabelName.SetText(deploy.Name);
        m_UI.m_LabelContent.SetText(deploy.FightContent);
        m_UI.m_LoaderHead.icon = UIUtil.GetEnemyHeadUrl(m_EnemyId);
    }

    protected override void OnInit()
    {
        base.OnInit();
        closeButton = m_UI.m_BtnEscape;
        m_UI.m_BtnFight.onClick.Set(OnClickFight);
    }

    private void OnClickFight(EventContext context)
    {
        Hide();

        var fightController = AdventureController.inst.gameObject.GetComponent<FightController>();
        fightController.StartFight(m_TilePoint, m_EnemyId);
    }
}
