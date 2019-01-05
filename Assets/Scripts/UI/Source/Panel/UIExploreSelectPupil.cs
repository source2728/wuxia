using Common;
using Explore;
using FairyGUI;
using Pupil;
using System;

public class UIExploreSelectPupil : PanelWin<UI_ExploreSelectPupil>
{
    public delegate void SelectDelegate(int id);
    public SelectDelegate OnSelect = new SelectDelegate(DelegateFunction);
    public static void DelegateFunction(int id) { }

    public UIExploreSelectPupil()
    {
        CommonBinder.BindAll();
        ExploreBinder.BindAll();
        PupilBinder.BindAll();
        UIPackage.AddPackage("UI/Common");
        UIPackage.AddPackage("UI/Explore");
        UIPackage.AddPackage("UI/Pupil");
    }

    public override void OnRefresh()
    {
        m_UI.m_List.SetData(PupilProxy.instance.GetPupilIds());
    }

    protected override void OnInit()
    {
        base.OnInit();
        m_UI.m_List.onClickItem.AddCapture(OnSelectPupil);
        m_UI.m_List.itemRenderer = pupilItemRenderer;
    }

    private void pupilItemRenderer(int index, GObject item)
    {
        var id = m_UI.m_List.GetData<int>(index);
        var pupilData = PupilProxy.instance.getPupilInfo(id);
        var deploy = pupilData.GetDeploy();

        var listItem = item as UI_PupilListItem;
        listItem.m_LabelName.SetText(deploy.Name);
        listItem.m_LabelCombat.SetValue(pupilData.GetCombat());
        listItem.m_LabelWuXing.SetText(pupilData.GetAttr(EAttrType.WuXing));
        listItem.m_LabelZiZhi.SetText(pupilData.GetAttr(EAttrType.ZiZhi));
        listItem.m_LabelWaiGong.SetText(pupilData.GetAttr(EAttrType.WaiGong));
        listItem.m_LabelNeiGong.SetText(pupilData.GetAttr(EAttrType.NeiGong));
        listItem.m_LabelShenFa.SetText(pupilData.GetAttr(EAttrType.ShenFa));
        listItem.m_LabelLevel.SetValue(pupilData.Level);
        listItem.m_IconHead.icon = UIUtil.GetPupilHeadUrl(deploy.Sex);
        listItem.m_StarLevel.AsStarLevel().SetLevel(deploy.StarLevel);
    }

    private void OnSelectPupil(EventContext context)
    {
        var id = m_UI.m_List.GetSelectedData<int>();
        OnSelect(id);
        Hide();
    }
}
