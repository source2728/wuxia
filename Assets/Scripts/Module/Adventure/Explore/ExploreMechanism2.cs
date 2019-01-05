using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ExploreMechanism2 : MonoBehaviour, IExploreMechanism
{
    protected Dictionary<int, GameObject> m_ShowingTileGoMap = new Dictionary<int, GameObject>();
    protected MapController m_MapController;
    protected int ExploreRange = 0;

    public void SetMapController(MapController mapController)
    {
        m_MapController = mapController;
    }

    public void StartExplore(Vector2 tilePoint, int range)
    {
        ExploreRange = range;
        m_MapController.UnExploreAll();
        ShowMapRange(tilePoint, range);
    }

    public void Explore(Vector2 tilePoint)
    {
        ShowMapRange(tilePoint, ExploreRange);
    }

    protected void ShowMapRange(Vector2 tilePoint, int range)
    {
        int x = (int)tilePoint.x;
        int y = (int)tilePoint.y;

        int range2 = range * 2;
        for (int i = x - range; i <= x + range; i++)
        {
            for (int j = y - range; j <= y + range; j++)
            {
                if (m_MapController.IsInMap(i, j) && (Math.Abs(i - x) + Math.Abs(j - y)) < range2)
                {
                    int cid = MapHelper.GetCid(i, j);
                    GameObject tileGo = m_MapController.GetTileGo(cid);
                    if (tileGo != null)
                    {
                        tileGo.GetComponent<TileController>().ShowObject();
                        if (!m_ShowingTileGoMap.ContainsKey(cid))
                        {
                            m_ShowingTileGoMap.Add(cid, tileGo);
                        }
                    }
                }
            }
        }
    }
}
