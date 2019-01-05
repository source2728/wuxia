using System;
using Adventure;
using Common;
using FairyGUI;
using SkillCreate;

public class UIDialogPanel : PanelWin<UI_DialogPanel>
{
    protected TileController m_TileController;

    public UIDialogPanel()
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
        m_UI.m_State.selectedIndex = m_TileController.HasExplore ? 1 : 0;
    }

    protected override void OnInit()
    {
        base.OnInit();
        m_UI.m_BtnGain.onClick.Set(OnClickGain);
    }

    private void OnClickGain(EventContext context)
    {
        Hide();
        AdventureFacade.getInstance().MeetNpc();
        m_TileController.MeetNpc();
        AudioManager.inst.PlayAudioEffect("GainBox");
    }
}
