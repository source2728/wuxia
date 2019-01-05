using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

public class FinishAdventureCommand : SimpleCommand {

    public override void Execute(INotification notification)
    {
        var adventureProxy = Facade.RetrieveProxy(AdventureProxy.Name) as AdventureProxy;
        adventureProxy.FinishAdventure();

        // 数据更新
        AppFacade.getInstance().DataUpdated();
    }
}
