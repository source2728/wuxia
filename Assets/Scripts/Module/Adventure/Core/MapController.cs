using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using DragonBones;
using UnityEngine;

public class MapController : MonoBehaviour, IAStarMap
{
    protected Dictionary<int, GameObject> m_TileGoMap = new Dictionary<int, GameObject>();
    protected AStar m_AStar;
    protected int MapWidth = 0;
    protected int MapHeight = 0;

    void Awake()
    {
        m_AStar = new AStar(this);
    }

    public void LoadMap()
    {
        var jsonStr = Resources.Load<TextAsset>("Map/Map").text;
        var data = JsonUtility.FromJson<TiledMapData>(jsonStr);
        MapWidth = data.width;
        MapHeight = data.height;

        Dictionary<string, UnityEngine.Object> tileGoMap = new Dictionary<string, UnityEngine.Object>();
        for (int i = 0; i < data.tilesets.Length; i++)
        {
            var tileset = data.tilesets[i];
            tileGoMap.Add(tileset.name, Resources.Load("Map/" + tileset.name));
        }

        m_TileGoMap.Clear();
        for (int j = 0; j < data.layers.Length; j++)
        {
            var layer = data.layers[j];
            var layerDatas = layer.data;
            var tileType = MapHelper.GetTileType(layer.name);
            var isObject = layer.name == "object" || layer.name == "npc";
            for (int i = 0; i < layerDatas.Length; i++)
            {
                var id = layerDatas[i];
                if (id <= 0)
                {
                    continue;
                }

                int x = i % 20;
                int y = i / 20;
                var cid = MapHelper.GetCid(x, y);

                TileController tileController = null;
                GameObject tileGo = null;
                if (!m_TileGoMap.TryGetValue(cid, out tileGo))
                {
                    tileGo = new GameObject(x + "_" + y);
                    tileController = tileGo.AddComponent<TileController>();
                    tileController.SortingOrder = MapHelper.GetTileSortOrder(i);
                    tileGo.transform.SetParent(transform, true);
                    tileGo.transform.localPosition = MapHelper.GetMapPosition(x, y);
                    m_TileGoMap.Add(cid, tileGo);
                }

                if (tileController == null)
                {
                    tileController = tileGo.GetComponent<TileController>();
                }

                var tileset = data.tilesets[id - 1];               
                var go = Instantiate(tileGoMap[tileset.name]) as GameObject;
                go.transform.SetParent(tileGo.transform, true);
                var spriteRenderer = go.transform.GetChild(0).GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.sortingOrder = MapHelper.GetTileUnitSortOrder(tileController.SortingOrder, tileType);
                }
                else
                {
                    go.transform.GetChild(0).GetComponent<UnityArmatureComponent>().sortingOrder = MapHelper.GetTileUnitSortOrder(tileController.SortingOrder, tileType);
                }
                
                go.transform.localPosition = Vector3.zero;

                if (isObject)
                {
                    tileController.MapObjectType = (int) Enum.Parse(typeof(MapHelper.EMapObject), tileset.name);
                    var tileObject = go.AddComponent<TileObject>();
                    tileObject.Type = tileController.MapObjectType;
                }
                else
                {
                    tileController.MapObjectType = 0;
                }
            }
        }
    }

    public void HideAll()
    {
        foreach (var keyValuePair in m_TileGoMap)
        {
            keyValuePair.Value.SetActive(false);
        }
    }
    public void UnExploreAll()
    {
        foreach (var keyValuePair in m_TileGoMap)
        {
            keyValuePair.Value.SetActive(true);
            keyValuePair.Value.GetComponent<TileController>().HideObject();
        }
    }

    public TileController GetTileController(Vector2 tilePoint)
    {
        return m_TileGoMap[MapHelper.GetCid(tilePoint)].GetComponent<TileController>();
    }

    public GameObject GetTileGo(int x, int y)
    {
        int cid = MapHelper.GetCid(x, y);
        return GetTileGo(cid);
    }
    public GameObject GetTileGo(int cid)
    {
        GameObject tileGo = null;
        m_TileGoMap.TryGetValue(cid, out tileGo);
        return tileGo;
    }

    public Vector2 ScreenToTilePoint(Vector3 screenPoint)
    {
        var worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);
        var localPoint = transform.InverseTransformPoint(worldPoint);
        return MapHelper.MapToTilePoint(localPoint);
    }

    public Stack<ASPoint> FindPath(Vector2 startTile, Vector2 endTile)
    {
        return m_AStar.FindPath(new ASPoint((int)startTile.x, (int)startTile.y),
            new ASPoint((int)endTile.x, (int)endTile.y));
    }

    public bool IsInMap(int x, int y)
    {
        if (x < 0 || y < 0 || x >= MapWidth || y >= MapHeight)
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// 判断是否可行
    /// </summary>
    /// <returns><c>true</c>, if moveable was ised, <c>false</c> otherwise.</returns>
    /// <param name="point">Point.</param>
    public bool IsMoveable(ASPoint point)
    {
        if (!IsInMap(point.X, point.Y))
        {
            return false;
        }
        var cid = MapHelper.GetCid(point);

        GameObject tileGo;
        if (!m_TileGoMap.TryGetValue(cid, out tileGo))
        {
            return false;
        }

        if (!tileGo.activeSelf)
        {
            return false;
        }

        var tileController = tileGo.GetComponent<TileController>();
        return tileController.MapObjectType <= (int)MapHelper.EMapObject.Obstacle;
    }

    public void TileSink(Vector2 tilePoint)
    {
        var cid = MapHelper.GetCid(tilePoint);

        GameObject tileGo;
        if (m_TileGoMap.TryGetValue(cid, out tileGo))
        {
            var curY = tileGo.transform.localPosition.y;

            var sequence = DOTween.Sequence();
            sequence.Append(tileGo.transform.DOLocalMoveY(curY - 0.2f, 0.1f))
                .Append(tileGo.transform.DOLocalMoveY(curY, 0.1f));
        }
    }
}
