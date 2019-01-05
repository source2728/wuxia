using FairyGUI;
using SkillCreate;
using UnityEngine;

public class BuyListState : BaseViewState<UIWaiGongFang>
{
    protected UI_WaiGongFang m_UI;
    protected int m_HotIndex;

    public override void OnInit(UIWaiGongFang view)
    {
        base.OnInit(view);
        m_UI = view.m_UI;
        m_UI.m_BtnCreate.onClick.Set(OnClickCreate);
        m_UI.m_List.itemRenderer = OnItemRenderer;
    }

    public override void OnEnter()
    {
        var ids = BuyPlaceDeploy.GetIds();
        m_UI.m_List.SetData(ids);
        m_HotIndex = Random.Range(0, ids.Length);
    }

    private void OnItemRenderer(int index, GObject obj)
    {
        var id = m_UI.m_List.GetData<int>(index);
        var deploy = BuyPlaceDeploy.GetInfo(id);

        var item = obj as UI_BuyPlaceItem;
        item.m_LabelName.SetText(deploy.Name);
        item.m_LoaderIcon.icon = UIUtil.GetBuyPlaceUrl(id);
        item.m_LabelInfo1.SetVar("title", deploy.Title1).SetVar("value", deploy.Value1).FlushVars();
        item.m_LabelInfo2.SetVar("title", deploy.Title2).SetVar("value", deploy.Value2).FlushVars();
        item.m_Hot.selectedIndex = (m_HotIndex == index) ? 1 : 0;
    }

    private void OnClickCreate(EventContext context)
    {
        m_View.ChangeViewState(UIWaiGongFang.EViewState.SelectSkillType);
    }
}
