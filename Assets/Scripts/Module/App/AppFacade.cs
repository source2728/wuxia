using PureMVC.Patterns;

public class AppFacade : Facade
{

    public const string Name = "AppFacade";
    public const string NotifyStartUp = "NotifyStartUp";
    public const string NotifyDataUpdated = "NotifyDataUpdated";
    public const string NotifyResetData = "NotifyResetData";
    public const string NotifySaveData = "NotifySaveData";

    public const string NotifyEnterGame = "NotifyEnterGame";
    public const string NotifyEnterAdventure = "NotifyEnterAdventure";

    static AppFacade Inst = null;
    public static AppFacade getInstance()
    {
        if (Inst == null)
        {
            Inst = new AppFacade();
        }
        return Inst;
    }

    AppFacade() : base(Name)
    {

    }

    protected override void InitializeController()
    {
        base.InitializeController();
        RegisterCommand(NotifyStartUp, typeof(StartUpCommand));
        RegisterCommand(NotifySaveData, typeof(SaveGameCommand));
        RegisterCommand(NotifyResetData, typeof(ResetGameCommand));
        RegisterCommand(NotifyDataUpdated, typeof(DataUpdatedCommand));

        RegisterCommand(NotifyEnterGame, typeof(EnterGameSceneCommand));
        RegisterCommand(NotifyEnterAdventure, typeof(EnterAdventureSceneCommand));

        RegisterCommand(SkillCreateProxy.NotifySkillCreateUpdated, typeof(SaveGameCommand));
    }

    protected override void InitializeModel()
    {
        base.InitializeModel();
        RegisterProxy(PupilProxy.instance);
        RegisterProxy(BuildingProxy.instance);
        RegisterProxy(UserProxy.instance);
        RegisterProxy(GoodsProxy.instance);
        RegisterProxy(SkillCreateProxy.instance);
        RegisterProxy(UniqueSkillProxy.instance);
        RegisterProxy(AdventureProxy.instance);
        RegisterProxy(ExploreProxy.instance);
    }

    protected override void InitializeView()
    {
        base.InitializeView();
        RegisterMediator(new TipsMediator());
    }

    public void StartUp(AppController app)
    {
        SendNotification(NotifyStartUp, app);
    }

    public void EnterGameScene()
    {
        SendNotification(NotifyEnterGame);
    }

    public void EnterAdventureScene(int pupilId)
    {
        SendNotification(NotifyEnterAdventure, pupilId);
    }

    public void DataUpdated()
    {
        SendNotification(NotifyDataUpdated);
    }

    public void DataReset()
    {
        SendNotification(NotifyResetData);
    }

    public void DataSave()
    {
        SendNotification(NotifySaveData);
    }
}
