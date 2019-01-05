using PureMVC.Patterns;
using System.Collections.Generic;

public class SkillCreateFacade : Facade
{
    public const string Name = "SkillCreateFacade";

    public const string NotifyCreateStart = "NotifyCreateStart";
    public const string NotifyCreateStartSuccess = "NotifyCreateStartSuccess";
    public const string NotifyCreateFinish = "NotifyCreateFinish";
    public const string NotifyCreateFinishSuccess = "NotifyCreateFinishSuccess";

    public const string NotifyGiveUpEvent = "NotifyGiveUpEvent";
    public const string NotifyGiveUpEventSuccess = "NotifyGiveUpEventSuccess";
    public const string NotifyTryEvent = "NotifyTryEvent";
    public const string NotifySelectPowerUpEvent = "NotifySelectPowerUpEvent";
    public const string NotifySelectQualityUpEvent = "NotifySelectQualityUpEvent";

    static SkillCreateFacade Inst = null;
    public static SkillCreateFacade getInstance()
    {
        if (Inst == null)
        {
            Inst = new SkillCreateFacade();
        }
        return Inst;
    }

    SkillCreateFacade() : base(Name)
    {

    }

    protected override void InitializeModel()
    {
        base.InitializeModel();
        RegisterProxy(PupilProxy.instance);
        RegisterProxy(SkillCreateProxy.instance);
        RegisterProxy(GoodsProxy.instance);
        RegisterProxy(UniqueSkillProxy.instance);
    }

    protected override void InitializeController()
    {
        base.InitializeController();
        RegisterCommand(NotifyCreateStart, typeof(CreateStartCommand));
        RegisterCommand(NotifyGiveUpEvent, typeof(GiveUpEventCommand));
        RegisterCommand(NotifyCreateFinish, typeof(CreateFinishCommand));
        RegisterCommand(NotifyTryEvent, typeof(TryEventCommand));
        RegisterCommand(NotifySelectPowerUpEvent, typeof(SelectPowerUpEventCommand));
        RegisterCommand(NotifySelectQualityUpEvent, typeof(SelectQualityUpEventCommand));
    }

    protected override void InitializeView()
    {
        base.InitializeView();
        RegisterMediator(new SkillCreateMediator());
        RegisterMediator(new TipsMediator());
    }

    public void CreateSkill(SkillCreateData data)
    {
        SendNotification(NotifyCreateStart, data);
    }

    public void CreateSkillFinish(SkillCreateData data, string name)
    {
        SendNotification(NotifyCreateFinish, data, name);
    }

    public void GiveUpEvent()
    {
        SendNotification(NotifyGiveUpEvent);
    }

    public void TryEvent(int placeId)
    {
        SendNotification(NotifyTryEvent, placeId);
    }

    public void SelectPowerUpEvent(List<ItemData> itemDatas)
    {
        SendNotification(NotifySelectPowerUpEvent, itemDatas);
    }

    public void SelectQualityUpEvent(bool isWin)
    {
        SendNotification(NotifySelectQualityUpEvent, isWin);
    }
}
