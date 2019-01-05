using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine.SceneManagement;

public class EnterGameSceneCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        SceneManager.LoadScene("GameScene");
        WinCenter.inst.ClearAll();
        WinCenter.inst.ShowFirstView<UIMain>();
        AudioManager.inst.PlayBgAudio("Main");
    }
}
