using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickInput : MonoBehaviour
{
    public delegate void ClickDelegate(Vector3 point);
    public ClickDelegate OnClick = new ClickDelegate(DelegateFunction);
    public static void DelegateFunction(Vector3 point) { }

    protected bool HasMoved = false;
    protected Vector3? StartMousePos = null;

    void Update()
    {
        if (Input.touchCount >= 2 || Stage.isTouchOnUI)
        {
            HasMoved = false;
            StartMousePos = null;
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            HasMoved = false;
            StartMousePos = Input.mousePosition;
        }

        if (StartMousePos != null && Input.GetMouseButton(0))
        {
            if (Vector3.Distance(StartMousePos.Value, Input.mousePosition) > 10)
            {
                HasMoved = true;
            }
        }

        if (StartMousePos != null && Input.GetMouseButtonUp((0)))
        {
            if (Vector3.Distance(StartMousePos.Value, Input.mousePosition) > 10)
            {
                HasMoved = true;
            }
        }

        if (!HasMoved && StartMousePos != null && Input.GetMouseButtonUp(0))
        {
            OnClick(Input.mousePosition);
        }

        if (StartMousePos != null && Input.GetMouseButtonUp((0)))
        {
            HasMoved = false;
            StartMousePos = null;
        }
    }
}
