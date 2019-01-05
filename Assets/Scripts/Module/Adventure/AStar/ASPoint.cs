using UnityEngine;
using System.Collections;

public class ASPoint
{
    public ASPoint ParentPoint { get; set; }
    public int F { get; set; }
    public int G { get; set; }
    public int H { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public ASPoint(int x, int y)
    {
        X = x;
        Y = y;
    }

    public void CalF()
    {
        F = G + H;
    }
}
