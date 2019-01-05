using PureMVC.Interfaces;
using PureMVC.Patterns;

public class StartExploreCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        var exploreData = notification.Body as ExploreData;
        if (exploreData.PupilId1 <= 0 && exploreData.PupilId2 <= 0)
        {
            WinCenter.inst.ShowTips("还没有选择弟子！");
            return;
        }

        var explorePlaceDeploy = ExplorePlaceDeploy.GetInfo(exploreData.PlaceId);

        var userProxy = Facade.RetrieveProxy(UserProxy.Name) as UserProxy;
        userProxy.costGold(explorePlaceDeploy.Cost);

        var exploreProxy = Facade.RetrieveProxy(ExploreProxy.Name) as ExploreProxy;
        exploreProxy.StartExplore(exploreData);

        // 数据更新
        AppFacade.getInstance().DataUpdated();
    }
}
