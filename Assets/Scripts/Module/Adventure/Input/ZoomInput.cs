using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInput : MonoBehaviour
{
    public delegate void ZoomInDelegate();
    public delegate void ZoomOutDelegate();

    public ZoomInDelegate OnZoomIn = new ZoomInDelegate(DelegateFunction);
    public ZoomOutDelegate OnZoomOut = new ZoomOutDelegate(DelegateFunction);

    public static void DelegateFunction() { }

    protected float TwoFingerDis = 0;

    void Update()
    {
        var axis = Input.GetAxis("Mouse ScrollWheel");
        if (axis < 0)
        {
            OnZoomIn();
        }
        else if (axis > 0)
        {
            OnZoomOut();
        }

        if (Input.touchCount == 2)
        {
            var dis = Vector2.Distance(Input.touches[0].position, Input.touches[1].position);
            if (dis > TwoFingerDis)
            {
                OnZoomIn();
            }
            else if (dis < TwoFingerDis)
            {
                OnZoomOut();
            }
            TwoFingerDis = dis;
        }
        else
        {
            TwoFingerDis = 0;
        }
    }
}
