using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections.Generic;

public class ExploreMediator : Mediator
{
    public ExploreMediator() : base("ExploreMediator", null)
    {
    }

    public override IEnumerable<string> ListNotificationInterests
    {
        get
        {
            return new List<string>()
            {
                ExploreFacade.NotifyFinishExploreSuccess,
            };
        }
    }

    public override void HandleNotification(INotification notification)
    {
        switch (notification.Name)
        {
            case ExploreFacade.NotifyFinishExploreSuccess:
                WinCenter.inst.ShowPanel<UIExploreSuccessPanel>(notification.Body);
                break;

            default:
                break;
        }
    }
}
