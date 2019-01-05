using PureMVC.Interfaces;
using PureMVC.Patterns;

public class FinishExploreCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        var exploreProxy = Facade.RetrieveProxy(ExploreProxy.Name) as ExploreProxy;
        var data = exploreProxy.FinishExplore();

        var goodsProxy = Facade.RetrieveProxy(GoodsProxy.Name) as GoodsProxy;
        goodsProxy.AddItem(1, EGoodsType.XinFa, 1);
        goodsProxy.AddItem(1, EGoodsType.CanBen, 1);

        var userProxy = Facade.RetrieveProxy(UserProxy.Name) as UserProxy;
        userProxy.addGold(3000);

        // 数据更新
        AppFacade.getInstance().DataUpdated();

        Facade.SendNotification(ExploreFacade.NotifyFinishExploreSuccess, data);
    }
}
