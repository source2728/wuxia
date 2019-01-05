using PureMVC.Interfaces;
using PureMVC.Patterns;

public class ResetGameCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        var pupilProxy = Facade.RetrieveProxy(PupilProxy.Name) as PupilProxy;
        pupilProxy.resetData();

        var buildingProxy = Facade.RetrieveProxy(BuildingProxy.Name) as BuildingProxy;
        buildingProxy.resetData();

        var userProxy = Facade.RetrieveProxy(UserProxy.Name) as UserProxy;
        userProxy.resetData();

        var itemProxy = Facade.RetrieveProxy(GoodsProxy.Name) as GoodsProxy;
        itemProxy.resetData();

        var skillCreateProxy = Facade.RetrieveProxy(SkillCreateProxy.Name) as SkillCreateProxy;
        skillCreateProxy.resetData();

        var uniqueSkillProxy = Facade.RetrieveProxy(UniqueSkillProxy.Name) as UniqueSkillProxy;
        uniqueSkillProxy.resetData();

        var adventureProxy = Facade.RetrieveProxy(AdventureProxy.Name) as AdventureProxy;
        adventureProxy.resetData();

        var exploreProxy = Facade.RetrieveProxy(ExploreProxy.Name) as ExploreProxy;
        exploreProxy.resetData();

        Facade.SendNotification(AppFacade.NotifyDataUpdated);
    }
}
