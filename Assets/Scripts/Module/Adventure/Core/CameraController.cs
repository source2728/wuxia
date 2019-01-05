using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 offset;
    private GameObject LockTarget = null;
    protected Sequence m_MoveSequence;

    void LateUpdate()
    {
        if (LockTarget != null && m_MoveSequence == null)
        {
            Vector3 newCameraPos = LockTarget.transform.position + offset;
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, newCameraPos, 5 * UnityEngine.Time.deltaTime);
        }
    }

    public void LockToTarget(GameObject target)
    {
        var heroPosition = target.transform.localPosition;
        var targetPosition = new Vector3(heroPosition.x, heroPosition.y, Camera.main.transform.position.z);
        Camera.main.transform.position = targetPosition;

        offset = Camera.main.transform.position - target.transform.position;
        LockTarget = target;
    }

    public void UnlockTarget()
    {
        LockTarget = null;
    }

    public void SetPosition(Vector2 tilePoint)
    {
        var mapPosition = MapHelper.TileToMapPoint(tilePoint);
        Camera.main.transform.position = new Vector3(mapPosition.x, mapPosition.y, Camera.main.transform.position.z);
    }
}
