using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

public class OpenBoxCommand : SimpleCommand {

    public override void Execute(INotification notification)
    {
        var adventureProxy = Facade.RetrieveProxy(AdventureProxy.Name) as AdventureProxy;
        var goodsProxy = Facade.RetrieveProxy(GoodsProxy.Name) as GoodsProxy;

        // 随机物品
        var deploy = DropDeploy.GetInfo(1);
        var randIndex = Random.Range(0, 2);
        var dropItemInfo = deploy.DropInfos[randIndex];

        // 获得物品
        var goodsInfo = goodsProxy.AddItem(dropItemInfo.GoodsId, dropItemInfo.GoodsType, 1);

        // 记录物品
        adventureProxy.AddDropGoodsRecord(goodsInfo);

        // 数据更新
        AppFacade.getInstance().DataUpdated();

        WinCenter.inst.ShowTips("获得" + goodsInfo.Name);
    }
}
