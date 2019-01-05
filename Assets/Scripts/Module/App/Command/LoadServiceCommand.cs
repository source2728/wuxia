using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine.SceneManagement;

public class LoadServiceCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        var app = notification.Body as AppController;
        app.gameObject.AddComponent<SaveGameService>();
    }
}
