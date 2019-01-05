using PureMVC.Interfaces;
using PureMVC.Patterns;

public class DataUpdatedCommand : SimpleCommand {

    public override void Execute(INotification notification)
    {
        SaveGameService.DataUpdated();
        //DataCenter.dataUpdated();
    }
}
