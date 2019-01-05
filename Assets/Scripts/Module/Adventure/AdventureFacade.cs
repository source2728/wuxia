using PureMVC.Patterns;

public class AdventureFacade : Facade
{
    public const string Name = "AdventureFacade";

    public const string NotifyOpenBox = "NotifyOpenBox";
    public const string NotifyStartAdventure = "NotifyStartAdventure";
    public const string NotifyFinishAdventure = "NotifyFinishAdventure";
    public const string NotifyMeetNpc = "NotifyMeetNpc";

    static AdventureFacade Inst = null;
    public static AdventureFacade getInstance()
    {
        if (Inst == null)
        {
            Inst = new AdventureFacade();
        }
        return Inst;
    }

    AdventureFacade() : base(Name)
    {

    }

    protected override void InitializeController()
    {
        base.InitializeController();
        RegisterCommand(NotifyOpenBox, typeof(OpenBoxCommand));
        RegisterCommand(NotifyStartAdventure, typeof(StartAdventureCommand));
        RegisterCommand(NotifyFinishAdventure, typeof(FinishAdventureCommand));
        RegisterCommand(NotifyMeetNpc, typeof(MeetNpcCommand));
    }

    protected override void InitializeModel()
    {
        base.InitializeModel();
        RegisterProxy(AdventureProxy.instance);
        RegisterProxy(GoodsProxy.instance);
    }

    protected override void InitializeView()
    {
        base.InitializeView();
        RegisterMediator(new TipsMediator());
    }

    public void StartAdventure(int pupilId)
    {
        SendNotification(NotifyStartAdventure, pupilId);
    }

    public void FinishAdventure()
    {
        SendNotification(NotifyFinishAdventure);
    }

    public void OpenBox()
    {
        SendNotification(NotifyOpenBox);
    }

    public void MeetNpc()
    {
        SendNotification(NotifyMeetNpc);
    }
}

