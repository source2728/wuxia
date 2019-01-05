using Common;
using FairyGUI;
using Pupil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class UIPupilEquipPanel : PanelWin<UI_PupilEquipPanel>
{
    public delegate void SelectGoodsDelegate(ItemData itemData);
    public SelectGoodsDelegate OnSelectGoodsDelegate;

    protected EGoodsType GoodsType;

    public UIPupilEquipPanel()
    {
        CommonBinder.BindAll();
        PupilBinder.BindAll();
        UIPackage.AddPackage("UI/Common");
        UIPackage.AddPackage("UI/Pupil");
    }

    protected override void OnInit()
    {
        base.OnInit();
        m_UI.m_List.itemRenderer = goodsItemRenderer;
    }

    public override void OnUpdateData(params object[] d)
    {
        GoodsType = (EGoodsType)d[0];
    }

    public override void OnRefresh()
    {
        m_UI.m_Type.selectedIndex = (int) GoodsType;
        var list = GoodsProxy.instance.GetGoodsByType(GoodsType);
        m_UI.m_List.SetData(list);
    }

    private void goodsItemRenderer(int index, GObject obj)
    {
        var goodsInfo = m_UI.m_List.GetData<ItemData>(index);
        var item = obj as UI_PupilEquipItem;
        item.m_LabelName.SetText(goodsInfo.Name);
        item.m_LabelType.SetValue(Language.GetGoodsTypeName(goodsInfo.Type));
        item.m_LabelValue.SetValue(goodsInfo.Value);
        (item.m_Icon as UI_GoodsSmallIcon).m_State.selectedIndex = 1;
        item.m_Icon.icon = UIUtil.GetGoodsUrl(goodsInfo.Type, goodsInfo.Id);

        item.m_BtnSelect.data = goodsInfo;
        item.m_BtnSelect.onClick.Set(OnSelectGoods);
    }

    private void OnSelectGoods(EventContext context)
    {
        var goodsInfo = (context.sender as GObject).data as ItemData;
        Debug.Log(goodsInfo.Id);
        OnSelectGoodsDelegate?.Invoke(goodsInfo);
        Hide();
    }
}
