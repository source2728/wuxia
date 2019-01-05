using System;

[Serializable]
public class BuildData
{
    public bool IsShow = false;
    public bool IsLock = true;

    public int Id = 0;
    public int Level = 0;

    public int getNextLevelGoldCost()
    {
        return (Level + 1) * 100;
    }

    public int getHonorAdded()
    {
        return 100;
    }

    public bool isMaxLevel()
    {
        return Level >= 30;
    }
}
