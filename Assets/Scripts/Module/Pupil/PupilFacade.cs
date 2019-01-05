using PureMVC.Patterns;

public class PupilFacade : Facade
{
    public const string Name = "PupilFacade";

    public const string NotifyEquipWuXue = "NotifyEquipWuXue";

    static PupilFacade Inst = null;
    public static PupilFacade getInstance()
    {
        if (Inst == null)
        {
            Inst = new PupilFacade();
        }
        return Inst;
    }

    PupilFacade() : base(Name)
    {

    }

    protected override void InitializeModel()
    {
        base.InitializeModel();
        RegisterProxy(PupilProxy.instance);
        RegisterProxy(GoodsProxy.instance);
    }
     
    protected override void InitializeController()
    {
        base.InitializeController();
        RegisterCommand(NotifyEquipWuXue, typeof(EquipWuXueCommand));
    }

    protected override void InitializeView()
    {
        base.InitializeView();
        RegisterMediator(new TipsMediator());
    }

    public void EquipWuXue(int pupilId, ItemData itemData)
    {
        object[] param = new[] {(object)pupilId, itemData };
        SendNotification(NotifyEquipWuXue, param);
    }
}
