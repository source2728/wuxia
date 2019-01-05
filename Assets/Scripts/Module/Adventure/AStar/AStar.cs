using System;
using System.Collections.Generic;
using UnityEngine;

public class AStar
{
    protected IAStarMap Map;
    protected List<ASPoint> OpenList = new List<ASPoint>();
    protected List<ASPoint> CloseList = new List<ASPoint>();

    protected Dictionary<int, Dictionary<int, ASPoint>> PointPool = new Dictionary<int, Dictionary<int, ASPoint>>();

    public AStar(IAStarMap map)
    {
        Map = map;
    }

    public Stack<ASPoint> FindPath(ASPoint start, ASPoint end)
    {
        OpenList.Clear();
        CloseList.Clear();
        PointPool.Clear();

        AddPointInPool(start);
        AddPointInPool(end);

        OpenList.Add(start);

        while (OpenList.Count > 0)
        {
            // 找到F最小的点
            var point = GetMinFOpenPoint();
            OpenList.Remove(point);
            CloseList.Add(point);

            //
            var surroundPoints = GetSurroundPoints(point);
            foreach (var p in surroundPoints)
            {
                if (OpenList.Contains(p))
                {
                    int newG = point.G + 10;
                    if (newG < p.G)
                    {
                        p.ParentPoint = point;
                        p.G = newG;
                        p.CalF();
                    }
                }
                else if (!CloseList.Contains(p))
                {
                    p.ParentPoint = point;
                    p.G = 10;
                    p.H = (Math.Abs(end.X - p.X) + Math.Abs(end.Y - p.Y)) * 10;
                    p.CalF();
                    OpenList.Add(p);
                }
            }

            if (OpenList.Contains(end))
            {
                Stack<ASPoint> path = new Stack<ASPoint>();
                ASPoint curPoint = end;
                do
                {
                    path.Push(curPoint);
                    curPoint = curPoint.ParentPoint;
                } while (curPoint != null);

                return path;
            }
        }
        return null;
    }

    /// <summary>
    /// 在开放列表中获取F最小的点
    /// </summary>
    /// <returns>The minimum FO pen point.</returns>
    public ASPoint GetMinFOpenPoint()
    {
        OpenList.Sort((ASPoint a, ASPoint b) =>
        {
            return a.F - b.F;
        });
        return OpenList[0];
    }

    /// <summary>
    /// 获取可行走的相邻点
    /// </summary>
    /// <returns>The surround points.</returns>
    /// <param name="point">Point.</param>
    public List<ASPoint> GetSurroundPoints (ASPoint point) 
    {
        var list = new List<ASPoint>();
        ASPoint[] points = 
        {
            GetPointFromPool(point.X + 1, point.Y),
            GetPointFromPool(point.X - 1, point.Y),
            GetPointFromPool(point.X, point.Y + 1),
            GetPointFromPool(point.X, point.Y - 1)
        };
        for (int i = 0; i < points.Length; i++)
        {
            var p = points[i];
            if (Map.IsMoveable(p))
            {
                list.Add(p);
            }
        }
        return list;
    }

    public void AddPointInPool(ASPoint point)
    {
        Dictionary<int, ASPoint> dict;
        if (!PointPool.TryGetValue(point.X, out dict))
        {
            dict = new Dictionary<int, ASPoint>();
            PointPool.Add(point.X, dict);
            dict.Add(point.Y, point);
        } 
        else if (!dict.ContainsKey(point.Y))
        {
            dict.Add(point.Y, point);
        }
    }

    public ASPoint GetPointFromPool (int x, int y)
    {
        Dictionary<int, ASPoint> dict;
        if (PointPool.TryGetValue(x, out dict))
        {
            ASPoint point;
            if (!dict.TryGetValue(y, out point))
            {
                point = new ASPoint(x, y);
                dict.Add(y, point);
            }
            return point;
        }
        else 
        {
            var point = new ASPoint(x, y);
            dict = new Dictionary<int, ASPoint>();
            PointPool.Add(x, dict);
            dict.Add(y, point);
            return point;
        }
    }
}
