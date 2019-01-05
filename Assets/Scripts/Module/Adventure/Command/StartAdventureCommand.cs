using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

public class StartAdventureCommand : SimpleCommand {

    public override void Execute(INotification notification)
    {
        var adventureProxy = Facade.RetrieveProxy(AdventureProxy.Name) as AdventureProxy;
        adventureProxy.StartAdventure((int)notification.Body);

        // 数据更新
        AppFacade.getInstance().DataUpdated();
    }
}
