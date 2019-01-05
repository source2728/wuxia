using System.Collections.Generic;
using UnityEngine;

public class MapHelper
{
    public enum ETileObject
    {
        Floor = 0,
        Rock,
        Object,
        Npc,
        Hero,
    }

    public enum EMapObject
    {
        None = 0,

        npc_001,
        npc_002,
        npc_003,
        npc_004,
        npc_005,
        npc_006,

        Obstacle = 100,
        grass_001,
        object_001,
        tree_001,
        stone_006,
        stone_005,
        house_001,
        house_002,
    }

    protected static Vector2 GridSize = new Vector2(1.33f, 0.72f);
    protected static Vector3 XVec = new Vector3(GridSize.x / 2, -GridSize.y / 2);
    protected static Vector3 YVec = new Vector3(-GridSize.x / 2, -GridSize.y / 2);

    protected static Dictionary<string, ETileObject> SortOrderStarts = new Dictionary<string, ETileObject>()
    {
        {"floor", ETileObject.Floor },
        {"rock", ETileObject.Rock },
        {"object", ETileObject.Object },
        {"npc", ETileObject.Npc }
    };

    public static Vector3 GetMapPosition(int x, int y)
    {
        return XVec * x + YVec * y;
    }

    public static Vector2 MapToTilePoint(Vector3 mapPosition)
    {
        float ox = mapPosition.x / GridSize.x;
        float oy = mapPosition.y / GridSize.y;
        int y = (int)Mathf.Floor(-ox - oy + 0.5f);
        int x = (int)Mathf.Floor(ox - oy + 0.5f);
        Debug.Log(string.Format("ox={0}, oy={1}, x={2}, y={3}", ox, oy, x, y));
        return new Vector2(x, y);
    }

    public static Vector3 TileToMapPoint(Vector2 tilePoint)
    {
        return XVec * tilePoint.x + YVec * tilePoint.y;
    }

    public static int GetTileIndex(Vector2 tilePoint)
    {
        return (int) tilePoint.y * 20 + (int) tilePoint.x;
    }

    public static int GetTileSortOrder(int tileIndex)
    {
        return tileIndex * 10;
    }

    public static ETileObject GetTileType(string objectType)
    {
        return SortOrderStarts[objectType];
    }

    public static int GetTileUnitSortOrder(Vector2 tilePoint, ETileObject type)
    {
        return GetTileUnitSortOrder(GetTileSortOrder(GetTileIndex(tilePoint)), type);
    }
    public static int GetTileUnitSortOrder(int tileSortOrder, ETileObject type)
    {
        return tileSortOrder + (int)type;
    }

    public static int GetCid(int x, int y)
    {
        return x * 10000 + y;
    }
    public static int GetCid(ASPoint point)
    {
        return GetCid(point.X, point.Y);
    }
    public static int GetCid(Vector2 point)
    {
        return GetCid((int)point.x, (int)point.y);
    }
}
