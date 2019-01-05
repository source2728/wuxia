using FairyGUI;
using PureMVC.Core;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections.Generic;

public class BaseWindow : Window
{
    protected List<string> m_NotificationNameList = new List<string>();
    protected override void OnShown()
    {
        base.OnShown();
        var view = View.GetInstance(AppFacade.Name) as View;
        view.RegisterObserver(AppFacade.NotifyDataUpdated, new Observer("OnNotifyDataUpdated", this));
        OnRegisterObservers();
        OnRefresh();
    }

    protected override void OnHide()
    {
        base.OnHide();
        var view = View.GetInstance(AppFacade.Name) as View;
        view.RemoveObserver(AppFacade.NotifyDataUpdated, this);
        foreach (var notificationName in m_NotificationNameList)
        {
            view.RemoveObserver(notificationName, this);
        }
    }

    public void OnNotifyDataUpdated(INotification notification)
    {
        OnRefresh();
    }

    public virtual void OnRefresh()
    {

    }

    public virtual void OnUpdateData(params object[] datas)
    {
    }

    protected virtual void OnRegisterObservers()
    {

    }

    protected void RegisterObserver(string notificationName, string funcName)
    {
        var view = View.GetInstance(AppFacade.Name) as View;
        view.RegisterObserver(notificationName, new Observer(funcName, this));
        m_NotificationNameList.Add(notificationName);
    }
}
