using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

public class LoadGameCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        var pupilProxy = Facade.RetrieveProxy(PupilProxy.Name) as PupilProxy;
        pupilProxy.loadData();
//        Debug.Log("LoadGameCommand pupilProxy :" + pupilProxy.getPupilInfo(1).Name);

        var buildingProxy = Facade.RetrieveProxy(BuildingProxy.Name) as BuildingProxy;
        buildingProxy.loadData();
        Debug.Log("LoadGameCommand buildingProxy :" + buildingProxy.getBuildingInfo(1));

        var userProxy = Facade.RetrieveProxy(UserProxy.Name) as UserProxy;
        userProxy.loadData();
        Debug.Log("LoadGameCommand userProxy :" + userProxy.getData().Gold);

        var itemProxy = Facade.RetrieveProxy(GoodsProxy.Name) as GoodsProxy;
        itemProxy.loadData();

        var skillCreateProxy = Facade.RetrieveProxy(SkillCreateProxy.Name) as SkillCreateProxy;
        skillCreateProxy.loadData();

        var uniqueSkillProxy = Facade.RetrieveProxy(UniqueSkillProxy.Name) as UniqueSkillProxy;
        uniqueSkillProxy.loadData();

        var adventureProxy = Facade.RetrieveProxy(AdventureProxy.Name) as AdventureProxy;
        adventureProxy.loadData();

        var exploreProxy = Facade.RetrieveProxy(ExploreProxy.Name) as ExploreProxy;
        exploreProxy.loadData();
    }
}
