using System;
using UnityEngine;

public class SaveGameService : MonoBehaviour
{
    static long NextSaveTime = 0;

    public static void DataUpdated()
    {
        NextSaveTime = TimeUtil.ConvertDateTimeToLong(System.DateTime.Now);
    }

    // Update is called once per frame
    void Update()
    {
        if (NextSaveTime > 0)
        {
            var curTime = TimeUtil.ConvertDateTimeToLong(System.DateTime.Now);
            if (curTime - NextSaveTime >= 1)
            {
                NextSaveTime = 0;
                AppFacade.getInstance().DataSave();
            }
        }
    }
}
