using System.Collections.Generic;
using UnityEngine;

public class TimeTickService : MonoBehaviour
{
    public static TimeTickService inst;

    protected List<TimeTick> m_TimeTickList = new List<TimeTick>();

    void Awake()
    {
        inst = this;
    }

    void Update()
    {
        var dt = UnityEngine.Time.deltaTime;

        List<TimeTick> finishedTicks = new List<TimeTick>();
        foreach (var timeTick in m_TimeTickList)
        {
            timeTick.LeftTimeToTick -= dt;
            if (timeTick.LeftTimeToTick <= 0)
            {
                var isFinished = timeTick.Tick();
                if (isFinished)
                {
                    finishedTicks.Add(timeTick);
                }
                else
                {
                    timeTick.LeftTimeToTick += timeTick.Interval;
                }
            }
        }

        foreach (var timeTick in finishedTicks)
        {
            m_TimeTickList.Remove(timeTick);
        }
    }

    public TimeTick AddTimeTick(float interval, TimeTick.TickDelegate tickFunc)
    {
        TimeTick timeTick = new TimeTick();
        timeTick.Interval = interval;
        timeTick.LeftTimeToTick = interval;
        timeTick.OnTick = tickFunc;
        m_TimeTickList.Add(timeTick);
        return timeTick;
    }

    public void RemoveTimeTick(TimeTick timeTick)
    {
        m_TimeTickList.Remove(timeTick);
    }
}
