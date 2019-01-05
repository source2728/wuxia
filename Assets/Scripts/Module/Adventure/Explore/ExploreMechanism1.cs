using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ExploreMechanism1 : MonoBehaviour, IExploreMechanism
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
        m_MapController.HideAll();
        ShowMapRange(tilePoint, range, false);
    }

    public void Explore(Vector2 tilePoint)
    {
        ShowMapRange(tilePoint, ExploreRange, true);
    }

    protected void ShowMapRange(Vector2 tilePoint, int range, bool showAni = true)
    {
        int x = (int)tilePoint.x;
        int y = (int)tilePoint.y;

        int range2 = range * 2;
        List<int> removeList = new List<int>();

        foreach (var keyValuePair in m_ShowingTileGoMap)
        {
            int i = keyValuePair.Key / 10000;
            int j = keyValuePair.Key % 10000;

            var tileGo = keyValuePair.Value;

            var ox = Math.Abs(i - x);
            var oy = Math.Abs(j - y);
            if ((ox + oy) >= range2 || ox > range || oy > range)
            {
                tileGo.GetComponent<TileController>().Hide();
                removeList.Add(keyValuePair.Key);
            }
        }
        for (int i = 0; i < removeList.Count; i++)
        {
            m_ShowingTileGoMap.Remove(removeList[i]);
        }
        removeList.Clear();

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
                        tileGo.GetComponent<TileController>().Show(showAni);
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
