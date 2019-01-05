using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections.Generic;

public class SelectPowerUpEventCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        var itemDatas = notification.Body as List<ItemData>;
        if (itemDatas.Count <= 0)
        {
            Facade.SendNotification(OptResultDefine.NotifyNotSelectCost, null, OptResultDefine.SelectCostTypeGoods);
            return;
        }

        var skillCreateProxy = Facade.RetrieveProxy(SkillCreateProxy.Name) as SkillCreateProxy;
        var createData = skillCreateProxy.GetData();
        var xinfaDeploy = XinFaDeploy.GetInfo(createData.SkillType);
        var canBenDeploy = CanBenDeploy.GetInfo(createData.SkillId);

        // 消耗道具
        var totalAddAttr = 0;
        foreach (var itemData in itemDatas)
        {
            var goodsDeploy = GoodsDeploy.GetInfo(itemData.Id);
            totalAddAttr += goodsDeploy.GetAddAttr(xinfaDeploy.Type);
            totalAddAttr += goodsDeploy.GetAddAttr(canBenDeploy.Type);
            GoodsProxy.instance.RemoveItem(itemData.Id, itemData.Type, 1);
        }
        
        // 触发概率
        bool isSuccess = true;
        if (isSuccess)
        {
            skillCreateProxy.BasePowerUp(totalAddAttr);
            Facade.SendNotification(OptResultDefine.NotifyCreateSkillPowerUpSuccess);
        }
        else
        {
            Facade.SendNotification(OptResultDefine.NotifyCreateSkillPowerUpFail);
        }

        // 提升威力奇遇
        skillCreateProxy.selectPowerUpEvent();

        // 数据更新
        AppFacade.getInstance().DataUpdated();
    }
}
