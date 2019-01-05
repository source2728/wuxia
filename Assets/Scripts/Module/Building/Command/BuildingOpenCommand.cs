using PureMVC.Interfaces;
using PureMVC.Patterns;

public class BuildingOpenCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        var buildingProxy = Facade.RetrieveProxy(BuildingProxy.Name) as BuildingProxy;

        var buildingId = (int)notification.Body;

        // 开放外功房
        if (buildingId == (int)EBuilding.ZhengDian)
        {
            var buildingData = buildingProxy.getBuildingInfo(buildingId);

            var building = buildingProxy.getBuildingInfo((int)EBuilding.WaiGongFang);
            if (building == null && GlobalDeploy.WaiGongOpenLevel <= buildingData.Level)
            {
                var buildingInfo = new BuildData();
                buildingInfo.IsShow = true;
                buildingInfo.IsLock = true;
                buildingInfo.Id = (int)EBuilding.WaiGongFang;
                buildingInfo.Level = 0;
                buildingProxy.addBuilding((int)EBuilding.WaiGongFang, buildingInfo);
            }

            building = buildingProxy.getBuildingInfo((int)EBuilding.ShangPu);
            if (building == null && GlobalDeploy.ShangPuOpenLevel <= buildingData.Level)
            {
                var buildingInfo = new BuildData();
                buildingInfo.IsShow = true;
                buildingInfo.IsLock = true;
                buildingInfo.Id = (int)EBuilding.ShangPu;
                buildingInfo.Level = 0;
                buildingProxy.addBuilding((int)EBuilding.ShangPu, buildingInfo);
            }
        }
    }
}
