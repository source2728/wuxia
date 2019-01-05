using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GragInput : MonoBehaviour
{
    public delegate void GargStartDelegate();
    public delegate void GargingDelegate(Vector3 offset);
    public delegate void GargEndDelegate();

    public delegate void InertiaStartDelegate();
    public delegate void InertiaingDelegate(Vector3 offset);
    public delegate void InertiaEndDelegate();


    protected Vector3? StartMousePos = null;
    protected bool HasMoved = false;
    protected Vector3? MoveSpeed = null;
    protected Vector3? Inertia = null;

    public GargStartDelegate OnGragStart = new GargStartDelegate(DelegateFunction);
    public GargingDelegate OnGraging = new GargingDelegate(DelegateFunction1);
    public GargEndDelegate OnGragEnd = new GargEndDelegate(DelegateFunction);

    public InertiaStartDelegate OnInertiaStart = new InertiaStartDelegate(DelegateFunction);
    public InertiaingDelegate OnInertiaing = new InertiaingDelegate(DelegateFunction1);
    public InertiaEndDelegate OnInertiaEnd = new InertiaEndDelegate(DelegateFunction);

    public static void DelegateFunction() { }
    public static void DelegateFunction1(Vector3 offset) { }

    void Update()
    {
        if (Input.touchCount >= 2)
        {
            StartMousePos = null;
            HasMoved = false;
            MoveSpeed = null;
            return;
        }

        if (Input.GetMouseButtonDown(0) && !Stage.isTouchOnUI)
        {
            StartMousePos = Input.mousePosition;
            HasMoved = false;
            MoveSpeed = null;
            Inertia = Vector3.zero;
        }

        if (MoveSpeed != null)
        {
            if (MoveSpeed.Value.magnitude > 1)
            {
                OnInertiaing(MoveSpeed.Value);
                MoveSpeed = MoveSpeed * 0.8f;
            }
            else
            {
                OnInertiaEnd();
                MoveSpeed = null;
            }
        }

        if (StartMousePos != null && Input.GetMouseButton(0))
        {
            if (!HasMoved)
            {
                if (Mathf.Abs(Input.mousePosition.x - StartMousePos.Value.x) > 10 ||
                    Mathf.Abs(Input.mousePosition.y - StartMousePos.Value.y) > 10)
                {
                    HasMoved = true;
                    OnGragStart();
                }
            }

            if (HasMoved)
            {
                Inertia = Input.mousePosition - StartMousePos.Value;
                OnGraging(Input.mousePosition - StartMousePos.Value);
                StartMousePos = Input.mousePosition;
            }
        }

        if (HasMoved && Input.GetMouseButtonUp(0))
        {
            MoveSpeed = Inertia;
            OnGragEnd();
            OnInertiaStart();
        }

        if (Input.GetMouseButtonUp(0))
        {
            StartMousePos = null;
            HasMoved = false;
        }
    }
}
