using System;
using System.Collections.Generic;

[Serializable]
public class AdventureData
{
    public int PupilId;
    public List<ItemData> GoodsList = new List<ItemData>();
    public List<AdventureEventData> EventList = new List<AdventureEventData>();
}
