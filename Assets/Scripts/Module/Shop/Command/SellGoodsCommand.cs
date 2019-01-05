using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

public class SellGoodsCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        var itemData = notification.Body as ItemData;

        var goodsProxy = Facade.RetrieveProxy(GoodsProxy.Name) as GoodsProxy;
        var userProxy = Facade.RetrieveProxy(UserProxy.Name) as UserProxy;

        goodsProxy.RemoveItem(itemData.Id, itemData.Type, itemData.Count);

        var gold = itemData.Value * itemData.Count;
        userProxy.addGold(gold);

        // 数据更新
        AppFacade.getInstance().DataUpdated();

        WinCenter.inst.ShowTips("出售" + itemData.Name + "获得" + gold + "金币");
    }
}
