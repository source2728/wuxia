using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;

public class TipsMediator : Mediator
{
    public TipsMediator() : base("TipsMediator", null)
    {
    }

    public override IEnumerable<string> ListNotificationInterests
    {
        get
        {
            return new List<string>() {
                BuildingFacade.NotifyBuildingLevelUpSuccess,
                BuildingFacade.NotifyBuildingUnlockSuccess,
                OptResultDefine.NotifyNotEnoughMoney,
                OptResultDefine.NotifyNotSelectCost,
                OptResultDefine.NotifyCreateSkillPowerUpSuccess,
                OptResultDefine.NotifyCreateSkillPowerUpFail,
            };
        }
    }

    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case BuildingFacade.NotifyBuildingLevelUpSuccess:
                ShowTips("升级成功！");
                break;

            case BuildingFacade.NotifyBuildingUnlockSuccess:
                ShowTips("解锁成功！");
                break;

            case OptResultDefine.NotifyNotEnoughMoney:
                ShowTips("金币不足！");
                break;

            case OptResultDefine.NotifyNotSelectCost:
            {
                switch (notification.Type)
                {
                    case OptResultDefine.SelectCostTypeGoods:
                        ShowTips("未选择道具！");
                        break;
                }
                break;
            }

            case OptResultDefine.NotifyCreateSkillPowerUpSuccess:
                ShowTips("提升威力成功！");
                break;

            case OptResultDefine.NotifyCreateSkillPowerUpFail:
                ShowTips("提升威力失败！");
                break;
        }
    }

    protected void ShowTips(string content)
    {
        WinCenter.inst.ShowTips(content);
    }
}
