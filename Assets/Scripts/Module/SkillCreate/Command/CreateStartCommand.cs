using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

public class CreateStartCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        SkillCreateData data = notification.Body as SkillCreateData;
        if (data.PupilId <= 0)
        {
            Debug.Log("还没有选择弟子");
            return;
        }

        if (data.SkillId <= 0)
        {
            Debug.Log("还没有选择残本");
            return;
        }

        if (data.SkillType <= 0)
        {
            Debug.Log("还没有选择心法");
            return;
        }

        var goodsProxy = Facade.RetrieveProxy(GoodsProxy.Name) as GoodsProxy;
        goodsProxy.RemoveItem(data.SkillType, EGoodsType.XinFa, 1);
        goodsProxy.RemoveItem(data.SkillId, EGoodsType.CanBen, 1);

        // 开始创建技能
        var skillCreateProxy = Facade.RetrieveProxy(SkillCreateProxy.Name) as SkillCreateProxy;
        skillCreateProxy.startCreateSkill(data);
        Facade.SendNotification(SkillCreateFacade.NotifyCreateStartSuccess);

        // 数据更新
        AppFacade.getInstance().DataUpdated();
    }
}
