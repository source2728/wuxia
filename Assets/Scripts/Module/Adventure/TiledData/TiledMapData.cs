using System;

[Serializable]
public class TiledMapData
{
    public int height;
    public int width;
    public string type;
    public TiledTilesetData[] tilesets;
    public TiledLayerData[] layers;
}