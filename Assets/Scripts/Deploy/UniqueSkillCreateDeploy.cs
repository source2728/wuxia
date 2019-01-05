using System.Collections.Generic;

public class UniqueSkillCreateDeploy
{
    public struct Info
    {
        public int XinFaId;
        public int CanBenId;
        public int FitValue;
        public int SkillEffectId;
        public UniqueSkillAttr AttrPSMin;
        public UniqueSkillAttr AttrPSMax;
    }

    public static Dictionary<int, Info> Datas = new Dictionary<int, Info>()
    {
        {1, new Info() {XinFaId = 1, CanBenId = 1, FitValue = 60, SkillEffectId = 1,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 15, SkillPower = 10, Value = 30, Diff = 4},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 20, SkillPower = 15, Value = 40, Diff = 10}
        }},
        {2, new Info() {XinFaId = 1, CanBenId = 2, FitValue = 100, SkillEffectId = 1,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 25, SkillPower = 20, Value = 50, Diff = 8},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 40, SkillPower = 25, Value = 60, Diff = 20}
        }},
        {3, new Info() {XinFaId = 1, CanBenId = 3, FitValue = 35, SkillEffectId = 1,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 8, SkillPower = 3, Value = 15, Diff = 1},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 12, SkillPower = 7, Value = 25, Diff = 4}
        }},
        {4, new Info() {XinFaId = 1, CanBenId = 4, FitValue = 15, SkillEffectId = 1,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 3, SkillPower = 0, Value = 7, Diff = 0},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 7, SkillPower = 3, Value = 14, Diff = 2}
        }},
        {5, new Info() {XinFaId = 1, CanBenId = 5, FitValue = 15, SkillEffectId = 2,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 3, SkillPower = 0, Value = 7, Diff = 0},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 7, SkillPower = 3, Value = 14, Diff = 2}
        }},
        {6, new Info() {XinFaId = 1, CanBenId = 6, FitValue = 5, SkillEffectId = 2,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 2, SkillPower = 0, Value = 4, Diff = 0},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 4, SkillPower = 2, Value = 8, Diff = 1}
        }},
        {7, new Info() {XinFaId = 1, CanBenId = 7, FitValue = 70, SkillEffectId = 2,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 15, SkillPower = 13, Value = 35, Diff = 4},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 25, SkillPower = 17, Value = 45, Diff = 12}
        }},
        {8, new Info() {XinFaId = 1, CanBenId = 8, FitValue = 85, SkillEffectId = 2,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 22, SkillPower = 16, Value = 42, Diff = 9},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 36, SkillPower = 22, Value = 50, Diff = 18}
        }},

        {9, new Info() {XinFaId = 2, CanBenId = 1, FitValue = 15, SkillEffectId = 3,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 3, SkillPower = 0, Value = 7, Diff = 0},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 7, SkillPower = 3, Value = 14, Diff = 2}
        }},
        {10, new Info() {XinFaId = 2, CanBenId = 2, FitValue = 5, SkillEffectId = 3,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 2, SkillPower = 0, Value = 4, Diff = 0},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 4, SkillPower = 2, Value = 8, Diff = 1}
        }},
        {11, new Info() {XinFaId = 2, CanBenId = 3, FitValue = 75, SkillEffectId = 3,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 17, SkillPower = 14, Value = 36, Diff = 5},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 27, SkillPower = 19, Value = 47, Diff = 14}
        }},
        {12, new Info() {XinFaId = 2, CanBenId = 4, FitValue = 30, SkillEffectId = 3,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 7, SkillPower = 2, Value = 13, Diff = 1},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 11, SkillPower = 5, Value = 23, Diff = 4}
        }},
        {13, new Info() {XinFaId = 2, CanBenId = 5, FitValue = 60, SkillEffectId = 4,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 15, SkillPower = 10, Value = 30, Diff = 4},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 20, SkillPower = 15, Value = 40, Diff = 10}
        }},
        {14, new Info() {XinFaId = 2, CanBenId = 6, FitValue = 100, SkillEffectId = 4,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 25, SkillPower = 20, Value = 50, Diff = 8},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 40, SkillPower = 25, Value = 60, Diff = 20}
        }},
        {15, new Info() {XinFaId = 2, CanBenId = 7, FitValue = 30, SkillEffectId = 4,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 7, SkillPower = 2, Value = 13, Diff = 1},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 11, SkillPower = 5, Value = 23, Diff = 4}
        }},
        {16, new Info() {XinFaId = 2, CanBenId = 8, FitValue = 15, SkillEffectId = 4,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 3, SkillPower = 0, Value = 7, Diff = 0},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 7, SkillPower = 3, Value = 14, Diff = 2}
        }},

        {17, new Info() {XinFaId = 3, CanBenId = 1, FitValue = 5, SkillEffectId = 5,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 2, SkillPower = 0, Value = 4, Diff = 0},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 4, SkillPower = 2, Value = 8, Diff = 1}
        }},
        {18, new Info() {XinFaId = 3, CanBenId = 2, FitValue = 15, SkillEffectId = 5,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 3, SkillPower = 0, Value = 7, Diff = 0},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 7, SkillPower = 3, Value = 14, Diff = 2}
        }},
        {19, new Info() {XinFaId = 3, CanBenId = 3, FitValue = 80, SkillEffectId = 5,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 20, SkillPower = 15, Value = 40, Diff = 6},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 30, SkillPower = 20, Value = 50, Diff = 15}
        }},
        {20, new Info() {XinFaId = 3, CanBenId = 4, FitValue = 30, SkillEffectId = 5,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 7, SkillPower = 2, Value = 13, Diff = 1},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 11, SkillPower = 5, Value = 23, Diff = 4}
        }},
        {21, new Info() {XinFaId = 3, CanBenId = 5, FitValue = 100, SkillEffectId = 6,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 25, SkillPower = 20, Value = 50, Diff = 8},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 40, SkillPower = 25, Value = 60, Diff = 20}
        }},
        {22, new Info() {XinFaId = 3, CanBenId = 6, FitValue = 50, SkillEffectId = 6,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 13, SkillPower = 8, Value = 26, Diff = 3},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 28, SkillPower = 12, Value = 34, Diff = 7}
        }},
        {23, new Info() {XinFaId = 3, CanBenId = 7, FitValue = 10, SkillEffectId = 6,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 2, SkillPower = 0, Value = 6, Diff = 0},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 6, SkillPower = 2, Value = 12, Diff = 2}
        }},
        {24, new Info() {XinFaId = 3, CanBenId = 8, FitValue = 40, SkillEffectId = 6,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 10, SkillPower = 5, Value = 20, Diff = 2},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 15, SkillPower = 10, Value = 30, Diff = 6}
        }},

        {25, new Info() {XinFaId = 4, CanBenId = 1, FitValue = 80, SkillEffectId = 7,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 20, SkillPower = 15, Value = 40, Diff = 6},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 30, SkillPower = 20, Value = 50, Diff = 15}
        }},
        {26, new Info() {XinFaId = 4, CanBenId = 2, FitValue = 30, SkillEffectId = 7,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 7, SkillPower = 2, Value = 13, Diff = 1},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 11, SkillPower = 5, Value = 23, Diff = 4}
        }},
        {27, new Info() {XinFaId = 4, CanBenId = 3, FitValue = 10, SkillEffectId = 7,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 2, SkillPower = 0, Value = 6, Diff = 0},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 6, SkillPower = 2, Value = 12, Diff = 2}
        }},
        {28, new Info() {XinFaId = 4, CanBenId = 4, FitValue = 100, SkillEffectId = 7,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 25, SkillPower = 20, Value = 50, Diff = 8},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 40, SkillPower = 25, Value = 60, Diff = 20}
        }},
        {29, new Info() {XinFaId = 4, CanBenId = 5, FitValue = 5, SkillEffectId = 8,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 2, SkillPower = 0, Value = 4, Diff = 0},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 4, SkillPower = 2, Value = 8, Diff = 1}
        }},
        {30, new Info() {XinFaId = 4, CanBenId = 6, FitValue = 10, SkillEffectId = 8,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 2, SkillPower = 0, Value = 6, Diff = 0},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 6, SkillPower = 2, Value = 12, Diff = 1}
        }},
        {31, new Info() {XinFaId = 4, CanBenId = 7, FitValue = 30, SkillEffectId = 8,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 7, SkillPower = 2, Value = 13, Diff = 1},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 11, SkillPower = 5, Value = 23, Diff = 4}
        }},
        {32, new Info() {XinFaId = 4, CanBenId = 8, FitValue = 60, SkillEffectId = 8,
            AttrPSMin = new UniqueSkillAttr(){BasePower = 15, SkillPower = 10, Value = 30, Diff = 4},
            AttrPSMax = new UniqueSkillAttr(){BasePower = 20, SkillPower = 15, Value = 40, Diff = 10}
        }}
    };

    public static Info? GetInfo(int xinfa, int canben)
    {
        foreach (var data in Datas)
        {
            if (data.Value.XinFaId == xinfa && data.Value.CanBenId == canben)
            {
                return data.Value;
            }
        }
        return null;
    }
}
