using FairyGUI;
using Main;
using Fight;
using Adventure;
using Common;
using System;

public class UISelectPupilView : ViewWin<UI_SelectPupilView>
{
    protected int m_SelectedPupilId = 0;

    public UISelectPupilView()
    {
        CommonBinder.BindAll();
        AdventureBinder.BindAll();
        UIPackage.AddPackage("UI/Common");
        UIPackage.AddPackage("UI/Adventure");
    }

    public override void OnRefresh()
    {
        m_UI.m_List.SetData(PupilProxy.instance.GetPupilIds());
        m_UI.m_SelectedPupilInfo.m_State.selectedIndex = 0;
    }

    protected override void OnInit()
    {
        base.OnInit();
        m_UI.m_BtnBack.onClick.Set(ViewBack);
        m_UI.m_BtnStart.onClick.Set(OnClickStart);
        m_UI.m_List.itemRenderer = OnPupilItemRenderer;
        m_UI.m_List.onClickItem.Set(OnClickPupilItem);
    }

    private void OnClickPupilItem(EventContext context)
    {
        var id = m_UI.m_List.GetSelectedData<int>();
        var info = PupilProxy.instance.getPupilInfo(id);
        var deploy = PupilDeploy.GetInfo(id);

        var item = m_UI.m_SelectedPupilInfo;
        item.m_State.selectedIndex = 1;

        item.m_LabelName.SetText(deploy.Name);
        item.m_LabelLevel.SetValue(info.Level);
        item.m_LoaderHead.icon = UIUtil.GetPupilHeadUrl(deploy.Sex);
        item.m_StarLevel.AsStarLevel().SetLevel(deploy.StarLevel);

        m_SelectedPupilId = id;
    }

    private void OnPupilItemRenderer(int index, GObject obj)
    {
        var id = m_UI.m_List.GetData<int>(index);
        var info = PupilProxy.instance.getPupilInfo(id);
        var deploy = PupilDeploy.GetInfo(id);
        var item = obj as UI_PupilSelectItem;
        item.m_LabelName.SetText(deploy.Name);
        item.m_LabelLevel.SetValue(info.Level);
        item.m_StarLevel.AsStarLevel().SetLevel(deploy.StarLevel);
        item.m_LoaderHead.icon = UIUtil.GetPupilHeadUrl(deploy.Sex);
        item.m_LabelAttr1.SetText(info.GetAttr(EAttrType.ZiZhi));
        item.m_LabelAttr2.SetText(info.GetAttr(EAttrType.NeiGong));
    }

    private void OnClickStart(EventContext context)
    {
        AdventureFacade.getInstance().StartAdventure(m_SelectedPupilId);
        AppFacade.getInstance().EnterAdventureScene(m_SelectedPupilId);
    }
}
