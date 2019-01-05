using FairyGUI;
using SkillCreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using UnityEngine;

public class SelectXinFaState : BaseViewState<UIWaiGongFang>
{
    protected UI_WaiGongFang m_UI;

    public override void OnInit(UIWaiGongFang view)
    {
        base.OnInit(view);
        m_UI = view.m_UI;
        m_UI.m_ListSkillType.itemRenderer = SkillTypeItemRenderer;
        m_UI.m_ListSkillType.onClickItem.Set(OnSkillTypeSelected);
    }

    public override void OnEnter()
    {
        m_UI.m_ListSkillType.SetData(GoodsProxy.instance.GetGoodsByType(EGoodsType.XinFa));
        m_View.RefreshSelectBook();
    }

    private void SkillTypeItemRenderer(int index, GObject obj)
    {
        var item = obj as UI_SelectTypeItem;
        var itemData = m_UI.m_ListSkillType.GetData<ItemData>(index);
        var deploy = XinFaDeploy.GetInfo(itemData.Id);

        item.m_LabelName.text = deploy.Name;
        item.m_LabelCount.SetValue(itemData.Count);

        item.m_CondType.selectedIndex = (int)deploy.CondAttrType;
        item.m_LabelCond.SetValue(deploy.CondAttrValue);

        item.m_Type.selectedIndex = 0;
        item.m_LabelTypeValue.SetText(Language.GetQuality(deploy.Quality));

        var icon = item.m_Icon as UI_GoodsSmallIcon;
        icon.m_State.selectedIndex = 1;

        item.m_Icon.icon = UIPackage.GetItemURL("Common", deploy.Icon);
    }
    private void OnSkillTypeSelected(EventContext context)
    {
        var itemData = m_UI.m_ListSkillType.GetSelectedData<ItemData>();
        var deploy = XinFaDeploy.GetInfo(itemData.Id);

        m_View.Data.SkillType = itemData.Id;
        m_View.RefreshSelectBook();

        var icon = m_UI.m_BtnSelectType as UI_GoodsSmallIcon;
        icon.m_State.selectedIndex = 1;

        m_UI.m_BtnSelectType.icon = UIPackage.GetItemURL("Common", deploy.Icon);
    }
}
