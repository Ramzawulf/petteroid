using Helpers.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : Singleton<CameraBehaviour>
{

    public Transform FocalPoint;
    public float RotationSpeed;
    private Vector3 lastPosition;
    private Vector3 newPosition;

    void Start()
    {
        transform.LookAt(FocalPoint);
    }

    void Update()
    {
    }

    private void LateUpdate()
    {
        transform.LookAt(FocalPoint);
    }

    public void Rotate(Vector3 delta)
    {
        transform.LookAt(FocalPoint);

        if (Math.Abs(delta.x) > Math.Abs(delta.y))
        {
            transform.RotateAround(FocalPoint.position, Vector3.up * delta.x, Time.deltaTime * RotationSpeed);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, FocalPoint.position);

    }
}
