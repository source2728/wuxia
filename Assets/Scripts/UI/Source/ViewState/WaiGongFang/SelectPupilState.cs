using FairyGUI;
using SkillCreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class SelectPupilState : BaseViewState<UIWaiGongFang>
{
    protected UI_WaiGongFang m_UI;

    public override void OnInit(UIWaiGongFang view)
    {
        base.OnInit(view);
        m_UI = view.m_UI;
        m_UI.m_ListPupil.itemRenderer = PupilItemRenderer;
        m_UI.m_ListPupil.onClickItem.Set(OnPupilSelected);
        m_UI.m_BtnStartCreate.onClick.Set(OnClickStartCreate);// 开始研读
    }

    public override void OnEnter()
    {
        var ids = PupilProxy.instance.GetPupilIds();

        var xinfaDeploy = XinFaDeploy.GetInfo(m_View.Data.SkillType);
        var canBenDeploy = CanBenDeploy.GetInfo(m_View.Data.SkillId);
        var createDeploy = UniqueSkillCreateDeploy.GetInfo(m_View.Data.SkillType, m_View.Data.SkillId);

        m_UI.m_ListPupil.SetData(ids);

        m_UI.m_IconXinFaCond.icon = UIUtil.GetPupilAttUrl(xinfaDeploy.CondAttrType);
        m_UI.m_LabelXinFaCond.SetText(xinfaDeploy.CondAttrValue);

        m_UI.m_IconCanBenCond.icon = UIUtil.GetPupilAttUrl(canBenDeploy.CondAttrType);
        m_UI.m_LabelCanBenCond.SetText(canBenDeploy.CondAttrValue);

        m_UI.m_LabelCreateDiff.SetDiff(canBenDeploy.Difficulty);
        m_UI.m_LabelCreateFitness.SetFitness(createDeploy.Value.FitValue);

        m_UI.m_PupilSelected.selectedIndex = 0;
    }

    private void PupilItemRenderer(int index, GObject obj)
    {
        var id = m_UI.m_ListPupil.GetData<int>(index);
        var info = PupilProxy.instance.getPupilInfo(id);
        var deploy = PupilDeploy.GetInfo(id);
        var item = obj as UI_PupilSelectIcon;
        item.m_LabelName.SetText(deploy.Name);
        item.m_LabelLevel.SetValue(info.Level);

        var xinfaDeploy = XinFaDeploy.GetInfo(m_View.Data.SkillType);
        var canBenDeploy = CanBenDeploy.GetInfo(m_View.Data.SkillId);

        item.m_IconXinFaCond.icon = UIUtil.GetPupilAttUrl(xinfaDeploy.CondAttrType);
        item.m_IconCanBenCond.icon = UIUtil.GetPupilAttUrl(canBenDeploy.CondAttrType);

        item.m_LabelXinFaCond.SetText(info.GetAttr(xinfaDeploy.CondAttrType));
        item.m_LabelCanBenCond.SetText(info.GetAttr(canBenDeploy.CondAttrType));

        item.m_IconHead.icon = UIUtil.GetPupilHeadUrl(deploy.Sex);

        item.selected = false;
    }

    private void OnPupilSelected(EventContext context)
    {
        var id = m_UI.m_ListPupil.GetSelectedData<int>();
        m_View.Data.PupilId = id;
        var info = PupilProxy.instance.getPupilInfo(id);
        var deploy = PupilDeploy.GetInfo(id);

        m_UI.m_PupilSelected.selectedIndex = 1;

        m_UI.m_LabelSelectedPupilName.SetText(deploy.Name);
        m_UI.m_LabelSelectedPupilLevel.SetValue(info.Level);
        m_UI.m_IconSelectedPupilBody.icon = UIUtil.GetPupilBodyUrl(deploy.Sex);
    }

    /// <summary>
    /// 开始研读
    /// </summary>
    /// <param name="context"></param>
    private void OnClickStartCreate(EventContext context)
    {
        SkillCreateFacade.getInstance().CreateSkill(m_View.Data);
    }
}
