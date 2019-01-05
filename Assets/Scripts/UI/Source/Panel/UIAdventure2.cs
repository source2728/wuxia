using System;
using Common;
using FairyGUI;
using Main;
using SkillCreate;
using UnityEngine;

public class UIAdventure2 : PanelWin<UI_Adventure2>
{
    protected SkillCreateData Data = null;

    public UIAdventure2()
    {
        CommonBinder.BindAll();
        SkillCreateBinder.BindAll();
        UIPackage.AddPackage("UI/Common");
        UIPackage.AddPackage("UI/SkillCreate");
    }

    protected override void OnInit()
    {
        base.OnInit();
        closeButton = m_UI.m_BtnBack;
        m_UI.m_BtnUp.onClick.Add(OnClickUp);
    }

    public override void OnUpdateData(params object[] d)
    {
        Data = d[0] as SkillCreateData;
    }

    public override void OnRefresh()
    {
        m_UI.m_LabelQualityUp.SetValue(55);
    }

    private void OnClickUp(EventContext context)
    {
        var game = WinCenter.inst.TransView<UISmallGame1>();
        game.OnFinish = win =>
        {
            SkillCreateFacade.getInstance().SelectQualityUpEvent(win);
            Hide();
        };
    }
}
