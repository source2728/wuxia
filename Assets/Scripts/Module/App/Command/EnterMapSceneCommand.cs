using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine.SceneManagement;

public class EnterAdventureSceneCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        var pupilId = (int)notification.Body;
        if (pupilId <= 0)
        {
            WinCenter.inst.ShowTips("未选择弟子！");
            return;
        }

        SceneManager.LoadScene("AdventureScene");
        WinCenter.inst.ClearAll();
        WinCenter.inst.ShowFirstView<UIMapView>(pupilId);
        AudioManager.inst.PlayBgAudio("Adventure");
    }
}
