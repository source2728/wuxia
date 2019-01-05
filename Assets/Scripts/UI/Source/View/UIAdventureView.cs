using FairyGUI;
using Main;
using Adventure;
using Common;
using System;

public class UIAdventureView : ViewWin<UI_AdventureView>
{
    public UIAdventureView()
    {
        CommonBinder.BindAll();
        AdventureBinder.BindAll();
        UIPackage.AddPackage("UI/Common");
        UIPackage.AddPackage("UI/Adventure");
    }

    public override void OnRefresh()
    {
        m_UI.m_List.numItems = 1;
    }

    protected override void OnInit()
    {
        base.OnInit();
        m_UI.m_List.itemRenderer = OnAdventureItemRenderer;
        m_UI.m_BtnBack.onClick.Set(ViewBack);
    }

    private void OnAdventureItemRenderer(int index, GObject obj)
    {
        var item = obj as UI_AdventureItem;
        item.m_List.itemRenderer = (i, o) =>
        {
            var subItem = o as UI_AdventureSubItem;
            subItem.m_BtnSelect.onClick.Set((() =>
            {
                WinCenter.inst.TransView<UISelectPupilView>();
            }));
        };
        item.m_List.numItems = item.m_State.selectedIndex;
        item.m_List.ResizeToFit(item.m_State.selectedIndex);
        item.m_BtnDetail.onClick.Set(() => { item.m_State.selectedIndex = (item.m_State.selectedIndex + 1) % 2; });
        item.m_State.onChanged.Set((() =>
        {
            item.m_List.numItems = item.m_State.selectedIndex;
            item.m_List.ResizeToFit(item.m_State.selectedIndex);
        }));
        item.m_State.selectedIndex = 0;
    }
}
