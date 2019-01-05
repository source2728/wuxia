using FairyGUI;
using Main;
using PureMVC.Patterns;
using UnityEngine;

public class AppController : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(this);
        gameObject.AddComponent<TimeTickService>();
        gameObject.AddComponent<AudioManager>();
        UIPackage.AddPackage("UI/Common");
        UIConfig.defaultFont = "siyuan";
        UIConfig.buttonSound = UIPackage.GetItemAsset("Common", "ButtonClick") as NAudioClip;
        AppFacade.getInstance().StartUp(this);
    }
}
