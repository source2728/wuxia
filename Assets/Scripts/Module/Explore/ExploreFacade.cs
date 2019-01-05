using PureMVC.Patterns;
using System.Collections.Generic;

public class ExploreFacade : Facade
{
    public const string Name = "ExploreFacade";

    public const string NotifyStartExplore = "NotifyStartExplore";
    public const string NotifyExploreTimeUp = "NotifyExploreTimeUp";
    public const string NotifyFinishExplore = "NotifyFinishExplore";
    public const string NotifyFinishExploreSuccess = "NotifyFinishExploreSuccess";

    static ExploreFacade Inst = null;
    public static ExploreFacade getInstance()
    {
        if (Inst == null)
        {
            Inst = new ExploreFacade();
        }
        return Inst;
    }

    ExploreFacade() : base(Name)
    {

    }

    protected override void InitializeModel()
    {
        base.InitializeModel();
        RegisterProxy(UserProxy.instance);
        RegisterProxy(GoodsProxy.instance);
        RegisterProxy(ExploreProxy.instance);
    }

    protected override void InitializeController()
    {
        base.InitializeController();
        RegisterCommand(NotifyStartExplore, typeof(StartExploreCommand));
        RegisterCommand(NotifyFinishExplore, typeof(FinishExploreCommand));
        RegisterCommand(NotifyExploreTimeUp, typeof(ExploreTimeUpCommand));
    }

    protected override void InitializeView()
    {
        base.InitializeView();
        RegisterMediator(new TipsMediator());
        RegisterMediator(new ExploreMediator());
    }

    public void StartExplore(ExploreData data)
    {
        SendNotification(NotifyStartExplore, data);
    }

    public void FinishExplore()
    {
        SendNotification(NotifyFinishExplore);
    }
}
