using System;
using Bag;
using Common;
using FairyGUI;
using Main;
using UnityEngine;

public class UIBagItemInfo1 : PanelWin<UI_BagItemInfo1>
{
    protected ItemData Data = null;

    public UIBagItemInfo1()
    {
        CommonBinder.BindAll();
        BagBinder.BindAll();
        UIPackage.AddPackage("UI/Common");
        UIPackage.AddPackage("UI/Bag");
    }

    public override void OnUpdateData(params object[] d)
    {
        Data = d[0] as ItemData;
    }

    public override void OnRefresh()
    {
//        var deploy = GoodsDeploy.GetInfo(Data.Id);
        m_UI.m_LabelName.SetText(Data.Name);
        m_UI.m_LabelValue.SetValue(Data.Value);
        m_UI.m_LabelQuality.SetValue(Language.GetQuality(Data.Quality));

        if (Data.Type == EGoodsType.WuXue)
        {
            var uniqueSkillData = UniqueSkillProxy.instance.GetData(Data.Id);
            var skillEffectDeploy = SkillEffectDeploy.GetInfo(uniqueSkillData.Id);
            m_UI.m_LabelDesc.SetText(skillEffectDeploy.Desc);
        }
        else
        {
            m_UI.m_LabelDesc.SetText(Data.Desc);
        }

        m_UI.m_LabelCount.SetValue(Data.Count);
        m_UI.m_LabelType.SetValue(Language.GetGoodsTypeName(Data.Type));
        
        (m_UI.m_IconHead as UI_GoodsSmallIcon).m_State.selectedIndex = 1;
        m_UI.m_IconHead.icon = UIUtil.GetGoodsUrl(Data.Type, Data.Id);
    }

    protected override void OnInit()
    {
        base.OnInit();
        m_UI.m_BtnSell.onClick.Set(OnSell);
    }

    private void OnSell(EventContext context)
    {
        if (Data.Type == EGoodsType.WuXue)
        {
            WinCenter.inst.ShowPanel<UIGainSkill>(Data, 1);
        }
        else
        {
            var itemData = new ItemData();
            itemData.Name = Data.Name;
            itemData.Value = Data.Value;
            itemData.Id = Data.Id;
            itemData.Type = Data.Type;
            itemData.Count = 1;
            ShopFacade.getInstance().SellGoods(itemData);
        }
    }
}
