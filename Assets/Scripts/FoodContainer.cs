using System;
using Helpers.Unity;
using UnityEngine;
using System.Collections.Generic;

public class FoodContainer : Singleton<FoodContainer>, IClickable, IInteractable
{

    public Transform[] Placeholders;
    private int PlaceHolderIndex = 0;
    public int Capacity = 6;
    public Transform TargetPoint;
    private List<FoodBehaviour> Food;
    private GameObject FoodGOContainer;

    public Vector3 Destination
    {
        get
        {
            if (TargetPoint != null) return TargetPoint.position;
            else
                return transform.position;
        }
    }

    void Start()
    {
        Food = new List<FoodBehaviour>();
        FoodGOContainer = new GameObject("Food GO Container");
        FoodGOContainer.transform.SetParent(transform);
    }

    void Update()
    {

    }

    public void OnDrawGizmos()
    {
        if (Placeholders != null && Placeholders.Length > 0)
        {
            Gizmos.color = Color.red;
            foreach (Transform place in Placeholders)
            {
                Gizmos.DrawWireSphere(place.position, 0.15f);
            }
        }

        if (TargetPoint != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireCube(TargetPoint.position + Vector3.up * 0.05f, new Vector3(0.5f, 0.1f, 0.5f));
        }
    }

    internal void Add(FoodBehaviour foodBehaviour)
    {
        if (Food.Count < Capacity)
        {
            Food.Add(foodBehaviour);
            foodBehaviour.Disable();
            foodBehaviour.gameObject.transform.position = Placeholders[PlaceHolderIndex].position;
            PlaceHolderIndex = (PlaceHolderIndex + 1) % Placeholders.Length;
            foodBehaviour.transform.SetParent(FoodGOContainer.transform);
        }
    }

    public bool Consume()
    {
        if (Food != null && Food.Count > 0)
        {
            Food[0].Consume();
            Food.RemoveAt(0);
            return true;
        }
        return false;
    }

    public void OnClick(Vector3 hit)
    {
        if (Food.Count > 0)
            PetBehaviour.Instance.InteractWith(this);
    }

    public void Interact()
    {
        if (Consume())
        {
            PetBehaviour.Instance.Eat();
        }
    }
}
