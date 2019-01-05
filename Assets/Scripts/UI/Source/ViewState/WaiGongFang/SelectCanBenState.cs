using Common;
using FairyGUI;
using SkillCreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class SelectCanBenState : BaseViewState<UIWaiGongFang>
{
    protected UI_WaiGongFang m_UI;

    public override void OnInit(UIWaiGongFang view)
    {
        base.OnInit(view);
        m_UI = view.m_UI;
        m_UI.m_ListSkill.itemRenderer = SkillItemRenderer;
        m_UI.m_ListSkill.onClickItem.Set(OnSkillSelected);
    }

    public override void OnEnter()
    {
        m_UI.m_ListSkill.SetData(GoodsProxy.instance.GetGoodsByType(EGoodsType.CanBen));
        m_View.RefreshSelectBook();
    }

    private void SkillItemRenderer(int index, GObject obj)
    {
        var item = obj as UI_SelectTypeItem;
        var itemData = m_UI.m_ListSkill.GetData<ItemData>(index);
        var deploy = CanBenDeploy.GetInfo(itemData.Id);

        item.m_LabelName.text = deploy.Name;
        item.m_LabelCount.SetValue(itemData.Count);

        item.m_CondType.selectedIndex = (int)deploy.CondAttrType;
        item.m_LabelCond.SetValue(deploy.CondAttrValue);

        item.m_Type.selectedIndex = 1;
        item.m_LabelTypeValue.SetDiff(deploy.Difficulty);

        var icon = item.m_Icon as UI_GoodsSmallIcon;
        icon.m_State.selectedIndex = 1;

        item.m_Icon.icon = UIPackage.GetItemURL("Common", deploy.Icon);
    }
    private void OnSkillSelected(EventContext context)
    {
        var itemData = m_UI.m_ListSkill.GetSelectedData<ItemData>();
        var deploy = CanBenDeploy.GetInfo(itemData.Id);

        m_View.Data.SkillId = itemData.Id;
        m_View.RefreshSelectBook();

        var icon = m_UI.m_BtnSelectSkill as UI_GoodsSmallIcon;
        icon.m_State.selectedIndex = 1;

        m_UI.m_BtnSelectSkill.icon = UIPackage.GetItemURL("Common", deploy.Icon);
    }
}
