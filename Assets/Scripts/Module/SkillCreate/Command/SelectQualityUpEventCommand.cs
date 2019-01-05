using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;

public class SelectQualityUpEventCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        bool isWin = (bool) notification.Body;

        // 提升品质奇遇
        var skillCreateProxy = Facade.RetrieveProxy(SkillCreateProxy.Name) as SkillCreateProxy;
        if (isWin)
        {
            skillCreateProxy.SkillPowerUp(55);
        }
        skillCreateProxy.selectQualityUpEvent();

        // 数据更新
        AppFacade.getInstance().DataUpdated();
    }
}
