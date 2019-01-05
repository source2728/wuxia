using System;

[Serializable]
public class ExploreData
{
    public long StartTime = 0;       // 研读开始时间戳
    public long FinishTime = 0;      // 研读结束时间戳
    public int PlaceId = 0;
    public int PupilId1 = 0;
    public int PupilId2 = 0;

    public bool IsExploring()
    {
        return StartTime > 0;
    }

    public bool IsFinished()
    {
        return FinishTime > 0 && FinishTime <= TimeUtil.CurrentTime();
    }
}
