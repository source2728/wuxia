using PureMVC.Interfaces;
using PureMVC.Patterns;

public class BuildingLevelUpCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        var buildingProxy = Facade.RetrieveProxy(BuildingProxy.Name) as BuildingProxy;
        var userProxy = Facade.RetrieveProxy(UserProxy.Name) as UserProxy;
        var buildingId = (int)notification.Body;

        var buildingData = buildingProxy.getBuildingInfo(buildingId);
        var goldCost = buildingData.getNextLevelGoldCost();

        // 检测消耗
        if (!userProxy.hasEnoughGold(goldCost))
        {
            Facade.SendNotification(OptResultDefine.NotifyNotEnoughMoney);
            return;
        }

        // 消耗
        userProxy.costGold(goldCost);
        userProxy.addHonor(buildingData.getHonorAdded());

        // 建筑升级成功
        buildingProxy.buildingLevelUp(buildingData.Id);
        Facade.SendNotification(BuildingFacade.NotifyBuildingLevelUpSuccess, buildingId);

        // 数据更新
        AppFacade.getInstance().DataUpdated();
    }
}
