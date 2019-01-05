using FairyGUI;

public static class GTextFieldExt
{
    public static void SetValue(this GTextField textField, int data)
    {
        textField.SetVar("value", data.ToString()).FlushVars();
    }

    public static void SetValue(this GTextField textField, string data)
    {
        textField.SetVar("value", data).FlushVars();
    }

    public static void SetCurAndMax(this GTextField textField, int cur, int max)
    {
        textField.SetVar("cur", cur.ToString()).SetVar("max", max.ToString()).FlushVars();
    }

    public static void SetText(this GTextField textField, int data)
    {
        textField.text = data.ToString();
    }

    public static void SetText(this GTextField textField, string data)
    {
        textField.text = data;
    }

    public static void SetGoodsName(this GTextField textField, EGoodsType type, int id)
    {
        switch (type)
        {
            case EGoodsType.DaoJu:
            {
                var deploy = GoodsDeploy.GetInfo(id);
                textField.text = deploy.Name;
                break;
            }    

            case EGoodsType.XinFa:
            {
                var deploy = XinFaDeploy.GetInfo(id);
                textField.text = deploy.Name;
                break;
            }

            case EGoodsType.CanBen:
            {
                var deploy = CanBenDeploy.GetInfo(id);
                textField.text = deploy.Name;
                break;
            }

            default:
                textField.text = "";
                break;
        }
    }
}
