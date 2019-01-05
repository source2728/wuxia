using PureMVC.Interfaces;
using PureMVC.Patterns;

public class SaveGameCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        var pupilProxy = Facade.RetrieveProxy(PupilProxy.Name) as PupilProxy;
        pupilProxy.saveData();

        var buildingProxy = Facade.RetrieveProxy(BuildingProxy.Name) as BuildingProxy;
        buildingProxy.saveData();

        var userProxy = Facade.RetrieveProxy(UserProxy.Name) as UserProxy;
        userProxy.saveData();

        var itemProxy = Facade.RetrieveProxy(GoodsProxy.Name) as GoodsProxy;
        itemProxy.saveData();

        var skillCreateProxy = Facade.RetrieveProxy(SkillCreateProxy.Name) as SkillCreateProxy;
        skillCreateProxy.saveData();

        var uniqueSkillProxy = Facade.RetrieveProxy(UniqueSkillProxy.Name) as UniqueSkillProxy;
        uniqueSkillProxy.saveData();

        var adventureProxy = Facade.RetrieveProxy(AdventureProxy.Name) as AdventureProxy;
        adventureProxy.saveData();

        var exploreProxy = Facade.RetrieveProxy(ExploreProxy.Name) as ExploreProxy;
        exploreProxy.saveData();
    }
}
