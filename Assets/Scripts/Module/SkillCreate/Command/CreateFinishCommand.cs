using PureMVC.Interfaces;
using PureMVC.Patterns;

public class CreateFinishCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        var createData = notification.Body as SkillCreateData;
        var name = notification.Type;

        // 创建技能
        var uniqueSkillProxy = Facade.RetrieveProxy(UniqueSkillProxy.Name) as UniqueSkillProxy;
        var uniqueSkill = uniqueSkillProxy.CreateUniqueSkill(createData, name);

        // 获得技能书
        var itemProxy = Facade.RetrieveProxy(GoodsProxy.Name) as GoodsProxy;
        var itemData = itemProxy.AddItem(uniqueSkill.Id, EGoodsType.WuXue, 1);

        // 完成创建
        var skillCreateProxy = Facade.RetrieveProxy(SkillCreateProxy.Name) as SkillCreateProxy;
        skillCreateProxy.finishCreateSkill();
        Facade.SendNotification(SkillCreateFacade.NotifyCreateFinishSuccess, itemData);

        // 数据更新
        AppFacade.getInstance().DataUpdated();
    }
}
