using System;
using Bag;
using Common;
using FairyGUI;
using Main;

public class UIBagView : ViewWin<UI_BagView>
{
    public UIBagView()
    {
        MainBinder.BindAll();
        CommonBinder.BindAll();
        BagBinder.BindAll();
        UIPackage.AddPackage("UI/Common");
        UIPackage.AddPackage("UI/Main");
        UIPackage.AddPackage("UI/Bag");
    }

    public override void OnRefresh()
    {
        if (m_UI.m_ViewState.selectedIndex <= 0)
        {
            m_UI.m_ViewState.selectedIndex = 1;
        }
    }

    protected override void OnInit()
    {
        base.OnInit();

        // 按钮绑定
        m_UI.m_BtnBack.onClick.Set(ViewBack);                    // 返回

        // 列表
        m_UI.m_List.onClickItem.Set(OnClickItem);
        m_UI.m_List.itemRenderer = goodsItemRenderer;

        m_UI.m_ViewState.onChanged.Set(OnSelectType);
        m_UI.m_ViewState.selectedIndex = 0;
    }

    private void OnSelectType(EventContext context)
    {
        if (m_UI.m_ViewState.selectedIndex > 0)
        {
            var goods = GoodsProxy.instance.GetGoodsByType((EGoodsType)m_UI.m_ViewState.selectedIndex);
            m_UI.m_List.SetData(goods);
            m_UI.m_LabelEmpty.visible = goods.Length <= 0;
            m_UI.m_LabelCount.SetCurAndMax(goods.Length, 999);
        }
        else
        {
            m_UI.m_LabelEmpty.visible = true;
            m_UI.m_LabelCount.SetCurAndMax(0, 999);
        }
    }

    private void goodsItemRenderer(int index, GObject item)
    {
        var goodsInfo = m_UI.m_List.GetData<ItemData>(index);
        var icon = item as UI_GoodsIcon;
        //        icon.m_LabelName.SetGoodsName(goodsInfo.Type, goodsInfo.Id);
        icon.m_LabelName.SetText(goodsInfo.Name);
        icon.m_LabelCount.SetValue(goodsInfo.Count);
        icon.m_IconHead.icon = UIUtil.GetGoodsUrl(goodsInfo.Type, goodsInfo.Id);
    }

    private void OnClickItem(EventContext context)
    {
        var goodsInfo = m_UI.m_List.GetSelectedData<ItemData>();
        WinCenter.inst.ShowPanel<UIBagItemInfo1>(goodsInfo);
//        WinCenter.inst.ShowPanel<UIBagItemInfo2>();
    }
}
