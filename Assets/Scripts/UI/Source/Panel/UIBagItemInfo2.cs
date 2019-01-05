using System;
using Bag;
using Common;
using FairyGUI;
using Main;
using UnityEngine;

public class UIBagItemInfo2 : PanelWin<UI_BagItemInfo2>
{
//    protected SkillCreateData Data = null;

    public UIBagItemInfo2()
    {
        CommonBinder.BindAll();
        BagBinder.BindAll();
        UIPackage.AddPackage("UI/Common");
        UIPackage.AddPackage("UI/Bag");
    }

    public override void OnUpdateData(params object[] d)
    {
//        Data = d[0] as SkillCreateData;
    }

    public override void OnRefresh()
    {
    }

    protected override void OnInit()
    {
        base.OnInit();
    }
}
