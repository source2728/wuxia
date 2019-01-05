using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections.Generic;

public class SkillCreateMediator : Mediator
{
    public SkillCreateMediator() : base("SkillCreateMediator", null)
    {
    }

    public override IEnumerable<string> ListNotificationInterests
    {
        get
        {
            return new List<string>()
            {
                SkillCreateFacade.NotifyCreateFinishSuccess,
            };
        }
    }

    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case SkillCreateFacade.NotifyCreateFinishSuccess:
                WinCenter.inst.ShowPanel<UIGainSkill>(notification.Body, 0);
                break;

            default:
                break;
        }
    }
}
