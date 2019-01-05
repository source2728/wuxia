using FairyGUI;
using SkillCreate;
using System;
using System.Diagnostics;
using Common;
using PureMVC.Interfaces;
using UnityEngine;

public class UIWaiGongFang : ViewWin<UI_WaiGongFang>
{
    public enum EViewState
    {
        None,
        BuyList,
        SelectSkillType,
        SelectSkill,
        SelectPupil,
        CreatingBeforeChoke,
        Choking,
        SelectPlace,
        CreatingBeforeEvent,
        SelectEvent,
        CreatingAfterEvent,
        CreateFinished,
    }

    protected string[] IconUrls = new string[] { "icon_012", "icon_011", "icon_010", "icon_009" };
    protected int ShowUpTipsCd = 2;

    public SkillCreateData Data;
    protected int LastPupilSelectIndex = -1;
    protected int LastPlaceSelectIndex = -1;
    protected ViewStateMachine<UIWaiGongFang> m_ViewStateMachine;

    public UIWaiGongFang()
    {
        CommonBinder.BindAll();
        SkillCreateBinder.BindAll();
        UIPackage.AddPackage("UI/Common");
        UIPackage.AddPackage("UI/SkillCreate");
    }

    public void ChangeViewState(EViewState state)
    {
        m_UI.m_ViewState.selectedPage = Enum.GetName(typeof(EViewState), state);
    }

    public void RefreshProgress()
    {
        m_UI.m_Progress.value = Data.getProgress();
    }

    protected override void OnRegisterObservers()
    {
        RegisterObserver(SkillCreateProxy.NotifySkillCreateUpdated, "OnNotifySkillCreateUpdated");
        RegisterObserver(SkillCreateProxy.NotifyChokeStart, "OnNotifyChokeStart");
        RegisterObserver(SkillCreateProxy.NotifyEventSelectStart, "OnNotifyEventSelectStart");
        RegisterObserver(SkillCreateProxy.NotifyCreateFinished, "OnNotifyCreateFinished");
    }

    /// <summary>
    /// 刷新页面
    /// </summary>
    public override void OnRefresh()
    {
        m_UI.m_ViewState.selectedIndex = 0;
        m_UI.m_GroupUpTips.alpha = 0;
        m_UI.m_CreatingBookInfo.m_IconUp.visible = false;

        var skillCreateProxy = AppFacade.getInstance().RetrieveProxy(SkillCreateProxy.Name) as SkillCreateProxy;
        if (!skillCreateProxy.isCreatingSkill())
        {
            Data = new SkillCreateData();
            (m_UI.m_BtnSelectType as UI_GoodsSmallIcon).m_State.selectedIndex = 0;
            (m_UI.m_BtnSelectSkill as UI_GoodsSmallIcon).m_State.selectedIndex = 0;
            ChangeViewState(EViewState.BuyList);
            return;
        }

        Data = skillCreateProxy.getData();
        if (Data.isCreateFinish())
        {
            ChangeViewState(EViewState.CreateFinished);
        }
        else if (Data.isEventFinish())
        {
            ChangeViewState(EViewState.CreatingAfterEvent);
        }
        else if (Data.isEventing())
        {
            ChangeViewState(EViewState.SelectEvent);
        }
        else if (Data.isChokeFinish())
        {
            ChangeViewState(EViewState.CreatingBeforeEvent);
        }
        else if (Data.isChoking())
        {
            ChangeViewState(EViewState.Choking);
        }
        else
        {
            ChangeViewState(EViewState.CreatingBeforeChoke);
        }
    }

    protected override void OnUpdate()
    {
        m_ViewStateMachine.OnUpdate();
    }

    protected override void OnInit()
    {
        base.OnInit();

        m_ViewStateMachine = new ViewStateMachine<UIWaiGongFang>(this, m_UI.m_ViewState);
        m_ViewStateMachine.AddViewState(Enum.GetName(typeof(EViewState), EViewState.BuyList), new BuyListState());
        m_ViewStateMachine.AddViewState(Enum.GetName(typeof(EViewState), EViewState.SelectSkillType), new SelectXinFaState());
        m_ViewStateMachine.AddViewState(Enum.GetName(typeof(EViewState), EViewState.SelectSkill), new SelectCanBenState());
        m_ViewStateMachine.AddViewState(Enum.GetName(typeof(EViewState), EViewState.SelectPupil), new SelectPupilState());
        m_ViewStateMachine.AddViewState(Enum.GetName(typeof(EViewState), EViewState.CreatingBeforeChoke), new CreatingBeforeChokeState());
        m_ViewStateMachine.AddViewState(Enum.GetName(typeof(EViewState), EViewState.Choking), new ChokingState());
        m_ViewStateMachine.AddViewState(Enum.GetName(typeof(EViewState), EViewState.SelectPlace), new SelectPlaceState());
        m_ViewStateMachine.AddViewState(Enum.GetName(typeof(EViewState), EViewState.CreatingBeforeEvent), new CreatingBeforeEventState());
        m_ViewStateMachine.AddViewState(Enum.GetName(typeof(EViewState), EViewState.SelectEvent), new SelectEventState());
        m_ViewStateMachine.AddViewState(Enum.GetName(typeof(EViewState), EViewState.CreatingAfterEvent), new CreatingAfterEventState());
        m_ViewStateMachine.AddViewState(Enum.GetName(typeof(EViewState), EViewState.CreateFinished), new CreateFinishedState());

        // 按钮绑定
        m_UI.m_BtnBack.onClick.Set(ViewBack);                 // 返回
        m_UI.m_BtnSelectBookFinish.onClick.Set(OnSelectBookFinish);

        m_UI.m_Progress.max = 1;
        m_UI.m_Progress.value = 0;

        m_UI.m_CreatingBookInfo.onAddedToStage.Set(OnRefreshCreatingBookInfo);
        m_UI.m_CreateSkillInfo.onAddedToStage.Set(OnRefreshCreateSkillInfo);

        var prefab = Resources.Load("Art_A/Effect/prefabs/UI_wx_zz_ldl");
        var go = UnityEngine.Object.Instantiate(prefab) as GameObject;
        go.transform.localScale = new Vector3(100, 100, 1);
        m_UI.m_FireEffect.SetNativeObject(new GoWrapper(go));

        prefab = Resources.Load("Art_A/Effect/prefabs/UI_wx_yd_xh");
        go = UnityEngine.Object.Instantiate(prefab) as GameObject;
        go.transform.localScale = new Vector3(100, 100, 1);
        m_UI.m_CreatingEffect.SetNativeObject(new GoWrapper(go));

        prefab = Resources.Load("Art_A/Effect/prefabs/UI_wx_yd_xh_1");
        go = UnityEngine.Object.Instantiate(prefab) as GameObject;
        go.transform.localScale = new Vector3(100, 100, 1);
        m_UI.m_CreatingEffect1.SetNativeObject(new GoWrapper(go));
    }

    public void OnRefreshPupilBody()
    {
        var deploy = PupilDeploy.GetInfo(Data.PupilId);
        m_UI.m_LoaderTopBody.icon = UIUtil.GetPupilBodyUrl(deploy.Sex);
        m_UI.m_LoaderBody.icon = UIUtil.GetPupilBodyUrl(deploy.Sex);
    }

    private void OnSelectBookFinish(EventContext context)
    {
        ChangeViewState(EViewState.SelectPupil);
    }

    public void RefreshSelectBook()
    {
        bool isAllSelected = Data.SkillType > 0 && Data.SkillId > 0;
        m_UI.m_BookSelected.selectedIndex = isAllSelected ? 1 : 0;

        if (isAllSelected)
        {
            var deploy = UniqueSkillCreateDeploy.GetInfo(Data.SkillType, Data.SkillId);
            m_UI.m_Fitness.icon = UIUtil.GetFitnessUrl(deploy.Value.FitValue);
        }
    }

    private void OnRefreshCreatingBookInfo(EventContext context)
    {
        var xinfaDeploy = XinFaDeploy.GetInfo(Data.SkillType);
        var canBenDeploy = CanBenDeploy.GetInfo(Data.SkillId);
        var createDeploy = UniqueSkillCreateDeploy.GetInfo(Data.SkillType, Data.SkillId);

        m_UI.m_CreatingBookInfo.m_IconXinFaCond.icon = UIUtil.GetPupilAttUrl(xinfaDeploy.CondAttrType);
        m_UI.m_CreatingBookInfo.m_IconCanBenCond.icon = UIUtil.GetPupilAttUrl(canBenDeploy.CondAttrType);
        m_UI.m_CreatingBookInfo.m_LabelXinFaCond.SetText(xinfaDeploy.CondAttrValue);
        m_UI.m_CreatingBookInfo.m_LabelCanBenCond.SetText(canBenDeploy.CondAttrValue);
        m_UI.m_CreatingBookInfo.m_IconDiff.icon = UIUtil.GetDiffUrl(canBenDeploy.Difficulty);

        if (Data.PlaceId > 0)
        {
            var placeDeploy = PlaceDeploy.GetInfo(Data.PlaceId);

            var fitness = placeDeploy.AddAtt.AddShenFa;
            if (xinfaDeploy.Type == ESkillType.NeiGong)
            {
                fitness += placeDeploy.AddAtt.AddNeiGong;
            }
            else if (xinfaDeploy.Type == ESkillType.WaiGong)
            {
                fitness += placeDeploy.AddAtt.AddWaiGong;
            }
            if (canBenDeploy.Type == ESkillType.DaoFa)
            {
                fitness += placeDeploy.AddAtt.AddDaoFa;
            }
            else if (canBenDeploy.Type == ESkillType.JianFa)
            {
                fitness += placeDeploy.AddAtt.AddJianFa;
            }
            m_UI.m_CreatingBookInfo.m_IconFitness.icon = UIUtil.GetFitnessUrl(createDeploy.Value.FitValue + fitness);
        }
        else
        {
            m_UI.m_CreatingBookInfo.m_IconFitness.icon = UIUtil.GetFitnessUrl(createDeploy.Value.FitValue);
        }
    }

    private void OnRefreshCreateSkillInfo(EventContext context)
    {
        m_UI.m_CreateSkillInfo.m_LabelBasePower.SetText(Data.BasePower);
        m_UI.m_CreateSkillInfo.m_LabelSkillPower.SetText(Data.SkillPower);
        m_UI.m_CreateSkillInfo.m_LabelValue.SetText(Data.Value);
        m_UI.m_CreateSkillInfo.m_LabelDiff.SetText(Data.Diff);

        m_UI.m_CreateSkillInfo.m_LabelBasePowerAdd.visible = Data.AppendAddBasePower > 0;
        m_UI.m_CreateSkillInfo.m_LabelBasePowerAdd.SetText("(" + Data.AppendAddBasePower + ")");
        m_UI.m_CreateSkillInfo.m_LabelSkillPowerAdd.visible = Data.AppendAddSkillPower > 0;
        m_UI.m_CreateSkillInfo.m_LabelSkillPowerAdd.SetText("(" + Data.AppendAddSkillPower + ")");

        ShowUpTipsCd -= 1;
        if (ShowUpTipsCd <= 0)
        {
            int[] values = { Data.LastAddBasePower, Data.LastAddSkillPower, Data.LastAddValue, Data.LastAddDiff };
            int index = UnityEngine.Random.Range(0, 4);
            m_UI.m_LoaderUpIcon.icon = UIPackage.GetItemURL("Common", IconUrls[index]);
            m_UI.m_LabelUpValue.SetValue(values[index]);
            m_UI.GetTransition("UpTips").Play();
            ShowUpTipsCd = 3;
        }
    }

    public void OnNotifySkillCreateUpdated(INotification notification)
    {
        OnRefreshCreateSkillInfo(null);
    }

    public void OnNotifyChokeStart(INotification notification)
    {
        ChangeViewState(EViewState.Choking);
    }

    public void OnNotifyEventSelectStart(INotification notification)
    {
        ChangeViewState(EViewState.SelectEvent);
    }

    public void OnNotifyCreateFinished(INotification notification)
    {
        ChangeViewState(EViewState.CreateFinished);
    }
}
