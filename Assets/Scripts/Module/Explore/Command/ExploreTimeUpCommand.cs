using PureMVC.Interfaces;
using PureMVC.Patterns;

public class ExploreTimeUpCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        // 数据更新
        AppFacade.getInstance().DataUpdated();
    }
}
