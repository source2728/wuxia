using System;
using Common;
using FairyGUI;
using Main;
using Pupil;

public class UIPupilView : ViewWin<UI_PupilView>
{
    protected int m_PupilId;

    public UIPupilView()
    {
        UIPackage.AddPackage("UI/Common");
        UIPackage.AddPackage("UI/Main");
        MainBinder.BindAll();
    }

    public override void OnUpdateData(params object[] datas)
    {
        m_PupilId = (int)datas[0];
    }

    public override void OnRefresh()
    {
        var pupilData = PupilProxy.instance.getPupilInfo(m_PupilId);
        var deploy = pupilData.GetDeploy();

        m_UI.m_LabelName.SetText(deploy.Name);
        m_UI.m_LabelLevel.SetValue(pupilData.Level);
        m_UI.m_LabelCombat.SetValue(pupilData.GetCombat());
        m_UI.m_StarLevel.AsStarLevelBig().SetLevel(deploy.StarLevel);
        m_UI.m_IconBody.icon = UIUtil.GetPupilBodyUrl(deploy.Sex);
        m_UI.m_Sex.selectedIndex = (int) deploy.Sex;

        if (m_UI.m_ViewState.selectedIndex == 0)
        {
            m_UI.m_ViewState.selectedIndex = 1;
        }

        m_UI.m_ProgressExp.max = pupilData.MaxExp;
        m_UI.m_ProgressExp.value = pupilData.CurExp;

        var equipingItem = pupilData.GetEquipingWuXue();
        if (equipingItem != null)
        {
            m_UI.m_JueXueState.selectedIndex = 1;
            (m_UI.m_IconWuXue as UI_GoodsSmallIcon).m_State.selectedIndex = 1;
            m_UI.m_IconWuXue.icon = UIUtil.GetGoodsUrl(equipingItem.Type, equipingItem.Id);
            m_UI.m_LabelWuXueName.SetText(equipingItem.Name);
            m_UI.m_LabelWuXueCombat.SetValue("9999");

            var uniqueSkillData = UniqueSkillProxy.instance.GetData(equipingItem.Id);
            var xinfaDeploy = XinFaDeploy.GetInfo(uniqueSkillData.SkillId1);
            var canbenDeploy = CanBenDeploy.GetInfo(uniqueSkillData.SkillId2);

            string str = (xinfaDeploy.Type == ESkillType.NeiGong) ? "内功" : "外功";
            string str1 = (canbenDeploy.Type == ESkillType.JianFa) ? "剑法" : "刀法";
            m_UI.m_LabelWuXueType.SetValue(str + str1);

            var skillEffectDeploy = SkillEffectDeploy.GetInfo(uniqueSkillData.Id);
            m_UI.m_LabelWuXueDesc.SetValue(skillEffectDeploy.Desc);
        }
        else
        {
            m_UI.m_JueXueState.selectedIndex = 0;
        }
    }

    protected override void OnInit()
    {
        base.OnInit();

        // 按钮绑定
        m_UI.m_BtnBack.onClick.AddCapture(ViewBack);                    // 返回
        m_UI.m_BtnEquipJueXue.onClick.Set(OnClickEquipJueXue);   // 装备武学
        m_UI.m_BtnChangeJueXue.onClick.Set(OnClickEquipJueXue);

        m_UI.m_TabPupilInfo.onAddedToStage.Set(OnShowTabPupilInfo);
    }

    private void OnShowTabPupilInfo(EventContext context)
    {
        var pupilData = PupilProxy.instance.getPupilInfo(m_PupilId);
        var deploy = pupilData.GetDeploy();

        var ui = m_UI.m_TabPupilInfo;
        ui.m_LabelWuXing.SetText(pupilData.GetAttr(EAttrType.WuXing));
        ui.m_LabelZiZhi.SetText(pupilData.GetAttr(EAttrType.ZiZhi));
        ui.m_LabelWaiGong.SetText(pupilData.GetAttr(EAttrType.WaiGong));
        ui.m_LabelNeiGong.SetText(pupilData.GetAttr(EAttrType.NeiGong));
        ui.m_LabelShenFa.SetText(pupilData.GetAttr(EAttrType.ShenFa));

        ui.m_LabelShengMing.SetValue(pupilData.GetAttr(EAttrType.ShengMing));
        ui.m_LabelZhenQi.SetValue(pupilData.GetAttr(EAttrType.ZhenQi));
        ui.m_LabelGongJi.SetValue(pupilData.GetAttr(EAttrType.GongJi));
        ui.m_LabelFangYu.SetValue(pupilData.GetAttr(EAttrType.FangYu));
        ui.m_LabelMingZhong.SetValue(pupilData.GetAttr(EAttrType.MingZhong));
        ui.m_LabelShanBi.SetValue(pupilData.GetAttr(EAttrType.ShanBi));
        ui.m_LabelBaoJi.SetValue(pupilData.GetAttr(EAttrType.BaoJi));
        ui.m_LabelKangBao.SetValue(pupilData.GetAttr(EAttrType.KangBao));

        ui.m_LabelDesc.SetText(deploy.Dese);
    }

    private void OnClickEquipJueXue(EventContext context)
    {
        var panel = WinCenter.inst.ShowPanel<UIPupilEquipPanel>(EGoodsType.WuXue);
        panel.OnSelectGoodsDelegate = OnEquipWuXue;
    }

    private void OnEquipWuXue(ItemData itemData)
    {
        PupilFacade.getInstance().EquipWuXue(m_PupilId, itemData);
    }
}
