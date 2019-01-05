using PureMVC.Interfaces;
using PureMVC.Patterns;

public class TryEventCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        var placeId = (int)notification.Body;

        // 放弃奇遇
        var skillCreateProxy = Facade.RetrieveProxy(SkillCreateProxy.Name) as SkillCreateProxy;
        skillCreateProxy.tryEvent(placeId);

        // 数据更新
        AppFacade.getInstance().DataUpdated();
    }
}
