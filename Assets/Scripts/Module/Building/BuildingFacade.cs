using PureMVC.Patterns;

public class BuildingFacade : Facade
{

    public const string Name = "BuildingFacade";

    public const string NotifyBuildingOpen = "NotifyBuildingOpen";
    public const string NotifyBuildingUnlock = "NotifyBuildingUnlock";
    public const string NotifyBuildingUnlockSuccess = "NotifyBuildingUnlockSuccess";

    public const string NotifyBuildingLevelUp = "NotifyBuildingLevelUp";
    public const string NotifyBuildingLevelUpSuccess = "NotifyBuildingLevelUpSuccess";

    static BuildingFacade Inst = null;
    public static BuildingFacade getInstance()
    {
        if (Inst == null)
        {
            Inst = new BuildingFacade();
        }
        return Inst;
    }

    public BuildingFacade() : base(Name)
    {

    }

    protected override void InitializeController()
    {
        base.InitializeController();
        RegisterCommand(NotifyBuildingLevelUpSuccess, typeof(BuildingOpenCommand));
        RegisterCommand(NotifyBuildingUnlock, typeof(BuildingUnlockCommand));
        RegisterCommand(NotifyBuildingLevelUp, typeof(BuildingLevelUpCommand));
    }

    protected override void InitializeModel()
    {
        base.InitializeModel();
        RegisterProxy(BuildingProxy.instance);
        RegisterProxy(UserProxy.instance);
    }

    protected override void InitializeView()
    {
        base.InitializeView();
        RegisterMediator(new TipsMediator());
    }

    public void BuildingLevelUp(int buildingId)
    {
        SendNotification(NotifyBuildingLevelUp, buildingId);
    }

    public void BuildingUnlock(int buildingId)
    {
        SendNotification(NotifyBuildingUnlock, buildingId);
    }
}
