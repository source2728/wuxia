using System;

[Serializable]
public class SkillCreateData
{

    public long StartTime = 0;       // 研读开始时间戳
    public long FinishTime = 0;      // 研读结束时间戳
    public long ChokeStartTime = 0;  // 研读瓶颈开始时间戳
    public long ChokeFinishTime = 0; // 研读瓶颈结束时间戳
    public long EventStartTime = 0;  // 研读奇遇开始时间戳
    public long EventFinishTime = 0; // 研读奇遇结束时间戳

    public long TotalTime = 0;   // 需要研读总时长

    public int PupilId = 0;
    public int SkillType = 0;
    public int SkillId = 0;
    public int PlaceId = 0;
    public int EventType = 0;

    public int BasePower = 0;
    public int SkillPower = 0;
    public int Value = 0;
    public int Diff = 0;
    public long LastCreateTime = 0;

    public int LastAddBasePower = 0;
    public int LastAddSkillPower = 0;
    public int LastAddValue = 0;
    public int LastAddDiff = 0;

    public int AppendAddBasePower = 0;
    public int AppendAddSkillPower = 0;

    public bool isChoking()
    {
        return ChokeFinishTime <= 0 && TimeUtil.ConvertDateTimeToLong(System.DateTime.Now) >= ChokeStartTime;
    }

    public bool isChokeFinish()
    {
        return ChokeFinishTime > 0;
    }

    public bool isEventing()
    {
        return EventStartTime > 0 && TimeUtil.ConvertDateTimeToLong(System.DateTime.Now) >= EventStartTime;
    }

    public bool isEventFinish()
    {
        return EventFinishTime > 0;
    }

    public bool isCreateFinish()
    {
        return FinishTime > 0 && TimeUtil.ConvertDateTimeToLong(System.DateTime.Now) >= FinishTime;
    }

    public float getProgress()
    {
        if (isCreateFinish())
        {
            return 1;
        }

        var curTime = TimeUtil.CurrentTime();
        long createdTime = 0;

        if (isEventFinish())
        {
            var chockTime = ChokeStartTime - StartTime;
            var eventTime = EventStartTime - ChokeFinishTime;
            createdTime = curTime - EventFinishTime + chockTime + eventTime;
        }
        else if (isEventing())
        {
            var chockTime = ChokeStartTime - StartTime;
            var eventTime = EventStartTime - ChokeFinishTime;
            createdTime = chockTime + eventTime;
        }
        else if (isChokeFinish())
        {
            var chockTime = ChokeStartTime - StartTime;
            createdTime = curTime - ChokeFinishTime + chockTime;
        }
        else if (isChoking())
        {
            createdTime = ChokeStartTime - StartTime;
        }
        else
        {
            createdTime = curTime - StartTime;
        }
        return Math.Min(1L, (float)createdTime / TotalTime);
    }

    public float GetChokingProgress()
    {
        long createdTime = ChokeStartTime - StartTime;
        return Math.Min(1L, (float)createdTime / TotalTime);
    }

    public float GetEventingProgress()
    {
        var chockTime = ChokeStartTime - StartTime;
        var eventTime = EventStartTime - ChokeFinishTime;
        long createdTime = chockTime + eventTime;
        return Math.Min(1L, (float)createdTime / TotalTime);
    }
}
