using System;
using UnityEngine;

public class FoodBehaviour : MonoBehaviour, IClickable
{
    private Rigidbody rb;
    private MeshCollider col;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<MeshCollider>();
        Disable();
    }

    public void Drop()
    {
        Enable();
    }

    public void OnClick(Vector3 hit)
    {
        FoodContainer.Instance.Add(this);
    }

    private void Enable()
    {
        rb.isKinematic = false;
        col.enabled = true;
    }

    internal void Disable()
    {
        rb.isKinematic = true;
        col.enabled = false;
    }

    internal void Consume()
    {
        Destroy(gameObject, 2f);
    }
}