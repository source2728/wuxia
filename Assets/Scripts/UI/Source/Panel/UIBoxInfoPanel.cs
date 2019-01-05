using System;
using Adventure;
using Common;
using FairyGUI;
using SkillCreate;

public class UIBoxInfoPanel : PanelWin<UI_BoxInfoPanel>
{
    protected TileController m_TileController;
    protected UI_GoodsSmallIconNoSel[] m_DropIcons = new UI_GoodsSmallIconNoSel[3];

    public UIBoxInfoPanel()
    {
        CommonBinder.BindAll();
        AdventureBinder.BindAll();
        UIPackage.AddPackage("UI/Common");
        UIPackage.AddPackage("UI/Adventure");
    }

    public override void OnUpdateData(params object[] d)
    {
        m_TileController = d[0] as TileController;
    }

    public override void OnRefresh()
    {
        var deploy = DropDeploy.GetInfo(1);
        for (int i = 0; i < 3; i++)
        {
            var dropInfo = deploy.DropInfos[i];
            var icon = m_DropIcons[i];
            icon.m_State.selectedIndex = 1;
            icon.icon = UIUtil.GetGoodsUrl(dropInfo.GoodsType, dropInfo.GoodsId);
        }
    }

    protected override void OnInit()
    {
        base.OnInit();
        closeButton = m_UI.m_BtnGiveUp;
        m_UI.m_BtnGainAll.onClick.Set(OnClickGainAll);
        m_DropIcons[0] = m_UI.m_IconDrop1 as UI_GoodsSmallIconNoSel;
        m_DropIcons[1] = m_UI.m_IconDrop2 as UI_GoodsSmallIconNoSel;
        m_DropIcons[2] = m_UI.m_IconDrop3 as UI_GoodsSmallIconNoSel;
    }

    private void OnClickGainAll(EventContext context)
    {
        Hide();
        AdventureFacade.getInstance().OpenBox();
        m_TileController.OpenBox();
        AudioManager.inst.PlayAudioEffect("GainBox");
    }
}
