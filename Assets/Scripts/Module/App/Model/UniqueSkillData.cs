using System;

[Serializable]
public class UniqueSkillData
{
    public int Id = 0;
    public string Name = "";
    public string CreatorName = "";
    public int SkillId1 = 0;
    public int SkillId2 = 0;
    public EGoodsQuality Quality = EGoodsQuality.None;
    public int DiffValue;
    public int Level;
    public int PracticePerLevel;
    public PupilAttr Attr;
    public int SkillEffectId;
    public int Value;
    public string Desc;
}
