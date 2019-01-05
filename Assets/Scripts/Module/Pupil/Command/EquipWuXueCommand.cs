using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

public class EquipWuXueCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        object[] param = notification.Body as object[];
        var pupilId = (int) param[0];
        var itemData = param[1] as ItemData;

        var goodsProxy = Facade.RetrieveProxy(GoodsProxy.Name) as GoodsProxy;
        var pupilProxy = Facade.RetrieveProxy(PupilProxy.Name) as PupilProxy;

        var pupilInfo = pupilProxy.getPupilInfo(pupilId);
        var equipingItem = pupilInfo.GetEquipingWuXue();

        // 卸下原有的武学
        if (equipingItem != null)
        {
            pupilInfo.EquipItems.Remove(equipingItem);
            goodsProxy.AddItem(equipingItem.Id, equipingItem.Type, 1);
        }

        // 装备上新的武学
        pupilInfo.EquipItems.Add(itemData);
        goodsProxy.RemoveItem(itemData.Id, itemData.Type, 1);

        // 数据更新
        AppFacade.getInstance().DataUpdated();

        WinCenter.inst.ShowTips("装备" + itemData.Name + "成功！");
    }
}
