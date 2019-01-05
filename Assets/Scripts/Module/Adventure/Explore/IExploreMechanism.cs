using UnityEngine;

public interface IExploreMechanism
{
    void SetMapController(MapController mapController);
    void StartExplore(Vector2 tilePoint, int range);
    void Explore(Vector2 tilePoint);
}