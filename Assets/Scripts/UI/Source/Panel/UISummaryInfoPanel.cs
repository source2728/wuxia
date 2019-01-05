using System;
using Adventure;
using Common;
using FairyGUI;

public class UISummaryInfoPanel : PanelWin<UI_SummaryInfoPanel>
{
    public UISummaryInfoPanel()
    {
        CommonBinder.BindAll();
        AdventureBinder.BindAll();
        UIPackage.AddPackage("UI/Common");
        UIPackage.AddPackage("UI/Adventure");
    }

    public override void OnUpdateData(params object[] d)
    {
    }

    public override void OnRefresh()
    {
        var data = AdventureProxy.instance.Data as AdventureData;
        var list = data.GoodsList.ToArray();
        m_UI.m_State.selectedIndex = list.Length > 0 ? 1 : 0;
        m_UI.m_DropList.SetData(list);
        m_UI.m_DropList.ResizeToFit(m_UI.m_DropList.numItems);
    }

    protected override void OnInit()
    {
        base.OnInit();
        m_UI.m_BtnCancel.onClick.Set(OnClickCancel);
        m_UI.m_BtnExit.onClick.Set(OnClickExit);
        m_UI.m_DropList.itemRenderer = OnDropItemRenderer;
    }

    private void OnDropItemRenderer(int index, GObject obj)
    {
        var item = obj as UI_GoodsSmallIconSmall;
        var info = m_UI.m_DropList.GetData<ItemData>(index);
        item.m_State.selectedIndex = 1;
        item.icon = UIUtil.GetGoodsUrl(info.Type, info.Id);
    }

    private void OnClickExit(EventContext context)
    {
        Hide();
        AppFacade.getInstance().EnterGameScene();
        AdventureFacade.getInstance().FinishAdventure();
    }

    private void OnClickCancel(EventContext context)
    {
        Hide();
    }
}
