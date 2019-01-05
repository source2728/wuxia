using System;
using Common;
using FairyGUI;
using Main;
using SkillCreate;
using UnityEngine;

public class UIGainSkill : PanelWin<UI_GainSkill>
{
    protected ItemData Data = null;
    protected int Type = 0;

    public UIGainSkill()
    {
        CommonBinder.BindAll();
        SkillCreateBinder.BindAll();
        UIPackage.AddPackage("UI/Common");
        UIPackage.AddPackage("UI/SkillCreate");
    }

    public override void OnUpdateData(params object[] d)
    {
        Data = d[0] as ItemData;
        Type = (int) d[1];
    }

    public override void OnRefresh()
    {
        var icon = m_UI.m_Icon as UI_GoodsSmallIcon;
        icon.m_State.selectedIndex = 1;
        m_UI.m_Icon.icon = UIUtil.GetGoodsUrl(Data.Type, Data.Id);

        var info = UniqueSkillProxy.instance.GetData(Data.Id);
        m_UI.m_LabelName.SetText(Data.Name);
        m_UI.m_LabelBasePower.SetText(info.Value);
        m_UI.m_LabelQuality.SetText(Language.GetQuality(info.Quality));

        m_UI.m_List.SetData(WantSellDeploy.GetIds());

        m_UI.m_ViewState.selectedIndex = Type;

        AudioManager.inst.PlayAudioEffect("CreateSuccess");
    }

    protected override void OnInit()
    {
        base.OnInit();
        m_UI.m_BtnNotSell.onClick.Set(OnClickNotSell);
        m_UI.m_List.itemRenderer = OnItemRenderer;
    }

    private void OnItemRenderer(int index, GObject obj)
    {
        var id = m_UI.m_List.GetData<int>(index);
        var deploy = WantSellDeploy.GetInfo(id);

        var item = obj as UI_WantBuyItem;
        item.m_LabelName.SetText(deploy.Name);
        item.m_LabelDesc.SetText(deploy.Desc);
        item.m_LoaderIcon.icon = UIUtil.GetBuyPlaceUrl(id);
        item.m_BtnSell.onClick.Set(OnClickBuy);
        item.m_BtnSell.data = id;
    }

    private void OnClickBuy(EventContext context)
    {
        var id = (int)(context.sender as GObject).data;
        var deploy = WantSellDeploy.GetInfo(id);

        var itemData = new ItemData();
        itemData.Name = Data.Name;
        itemData.Value = deploy.Value;
        itemData.Id = Data.Id;
        itemData.Type = Data.Type;
        itemData.Count = 1;
        ShopFacade.getInstance().SellGoods(itemData);
        Hide();
    }

    private void OnClickNotSell(EventContext context)
    {
        Hide();
    }
}
