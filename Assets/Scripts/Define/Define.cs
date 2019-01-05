using System.Runtime.Remoting.Messaging;

public class Define
{
    public static EFit ValueToFit(int value)
    {
        if (value <= 20)
            return EFit.Bad;
        else if (value <= 40)
            return EFit.Normal;
        else if (value <= 60)
            return EFit.Good;
        else if (value <= 80)
            return EFit.VeryGood;
        else
            return EFit.Perfect;
    }
}
