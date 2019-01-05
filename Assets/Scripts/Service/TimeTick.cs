public class TimeTick
{
    public delegate bool TickDelegate();
    
    public float Interval;
    public float LeftTimeToTick;
    public TickDelegate OnTick;

    public bool Tick()
    {
        if (OnTick == null)
            return true;
        return OnTick();
    }
}
