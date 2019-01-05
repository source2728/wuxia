using System;
using System.Collections.Generic;
using Common;
using FairyGUI;
using SkillCreate;

public class UIAdventure1 : PanelWin<UI_Adventure1>
{
    protected SkillCreateData Data = null;
    protected ItemData[] m_SelectItemDatas = new ItemData[3];
    protected UI_GoodsSmallIconNoSel[] m_ButtonIcons = new UI_GoodsSmallIconNoSel[3];

    public UIAdventure1()
    {
        CommonBinder.BindAll();
        SkillCreateBinder.BindAll();
        UIPackage.AddPackage("UI/Common");
        UIPackage.AddPackage("UI/SkillCreate");
    }

    protected override void OnInit()
    {
        base.OnInit();
        closeButton = m_UI.m_BtnBack;
        m_UI.m_BtnUp.onClick.Add(OnClickUp);
        m_UI.m_BtnGoods1.onClick.Set(OnSelectGoods1);
        m_UI.m_BtnGoods2.onClick.Set(OnSelectGoods2);
        m_UI.m_BtnGoods3.onClick.Set(OnSelectGoods3);

        m_ButtonIcons[0] = m_UI.m_BtnGoods1 as UI_GoodsSmallIconNoSel;
        m_ButtonIcons[1] = m_UI.m_BtnGoods2 as UI_GoodsSmallIconNoSel;
        m_ButtonIcons[2] = m_UI.m_BtnGoods3 as UI_GoodsSmallIconNoSel;
    }

    public override void OnUpdateData(params object[] d)
    {
        Data = d[0] as SkillCreateData;
    }

    public override void OnRefresh()
    {
        m_UI.m_LabelSuccess.SetValue(GlobalDeploy.BasePowerUpSuccessPro);
        m_UI.m_LabelPowerUp.SetValue(0);
        for (int i = 0; i < 3; i++)
        {
            m_ButtonIcons[i].m_State.selectedIndex = 0;
        }
    }

    private void OnClickUp(EventContext context)
    {
        List<ItemData> list = new List<ItemData>();
        for (int i = 0; i < 3; i++)
        {
            if (m_SelectItemDatas[i] != null)
            {
                list.Add(m_SelectItemDatas[i]);
            }
        }
        SkillCreateFacade.getInstance().SelectPowerUpEvent(list);
        Hide();
    }

    private void OnSelectGoods1(EventContext context)
    {
        var panel = WinCenter.inst.ShowPanel<UIPupilEquipPanel>(EGoodsType.DaoJu);
        panel.OnSelectGoodsDelegate = itemData => { OnSelectedGoods(itemData, 0); };
    }

    private void OnSelectGoods2(EventContext context)
    {
        var panel = WinCenter.inst.ShowPanel<UIPupilEquipPanel>(EGoodsType.DaoJu);
        panel.OnSelectGoodsDelegate = itemData => { OnSelectedGoods(itemData, 1); };
    }

    private void OnSelectGoods3(EventContext context)
    {
        var panel = WinCenter.inst.ShowPanel<UIPupilEquipPanel>(EGoodsType.DaoJu);
        panel.OnSelectGoodsDelegate = itemData => { OnSelectedGoods(itemData, 2); };
    }

    protected void OnSelectedGoods(ItemData data, int index)
    {
        m_SelectItemDatas[index] = data;
        m_ButtonIcons[index].m_State.selectedIndex = 1;
        m_ButtonIcons[index].icon = UIUtil.GetGoodsUrl(data.Type, data.Id);

        var xinfaDeploy = XinFaDeploy.GetInfo(Data.SkillType);
        var canBenDeploy = CanBenDeploy.GetInfo(Data.SkillId);

        var totalAddAttr = 0;
        for (int i = 0; i < 3; i++)
        {
            var selectedItemData = m_SelectItemDatas[i];
            if (selectedItemData != null)
            {
                var goodsDeploy = GoodsDeploy.GetInfo(selectedItemData.Id);
                totalAddAttr += goodsDeploy.GetAddAttr(xinfaDeploy.Type);
                totalAddAttr += goodsDeploy.GetAddAttr(canBenDeploy.Type);
            }
        }
        m_UI.m_LabelPowerUp.SetValue(totalAddAttr);
    }
}
