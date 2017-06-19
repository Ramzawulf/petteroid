using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{

    public float DeathTimer = 2f;

    void Awake()
    {
        Destroy(gameObject, DeathTimer);
    }
}
