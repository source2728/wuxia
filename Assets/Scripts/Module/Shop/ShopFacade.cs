using PureMVC.Patterns;

public class ShopFacade : Facade
{
    public const string Name = "ShopFacade";

    public const string NotifySellGoods = "NotifySellGoods";

    static ShopFacade Inst = null;
    public static ShopFacade getInstance()
    {
        if (Inst == null)
        {
            Inst = new ShopFacade();
        }
        return Inst;
    }

    ShopFacade() : base(Name)
    {

    }

    protected override void InitializeModel()
    {
        base.InitializeModel();
        RegisterProxy(GoodsProxy.instance);
        RegisterProxy(UserProxy.instance);
    }
     
    protected override void InitializeController()
    {
        base.InitializeController();
        RegisterCommand(NotifySellGoods, typeof(SellGoodsCommand));
    }

    protected override void InitializeView()
    {
        base.InitializeView();
        RegisterMediator(new TipsMediator());
    }

    public void SellGoods(ItemData itemData)
    {
        SendNotification(NotifySellGoods, itemData);
    }
}
