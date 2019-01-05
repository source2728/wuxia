using PureMVC.Interfaces;
using PureMVC.Patterns;

public class GiveUpEventCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        // 放弃奇遇
        var skillCreateProxy = Facade.RetrieveProxy(SkillCreateProxy.Name) as SkillCreateProxy;
        skillCreateProxy.giveUpEvent();
        Facade.SendNotification(SkillCreateFacade.NotifyGiveUpEventSuccess);

        // 数据更新
        AppFacade.getInstance().DataUpdated();
    }
}
