using Helpers.Unity;
using System.Collections.Generic;
using UnityEngine;

public class FoodGenerator : Singleton<FoodGenerator>, IClickable
{

    public Transform[] SpawningPoints;
    public int SpawningIndex = 0;

    public int Capacity;
    public List<GameObject> Food;
    public float GrowthSpeed;
    public float FoodTimer;
    private GameObject FoodContainer;

    void Start()
    {
        Food = new List<GameObject>();
        FoodTimer = Time.time;
        Capacity = Mathf.Min(Capacity, SpawningPoints.Length);
        FoodContainer = new GameObject("Food");
        FoodContainer.transform.SetParent(transform);
    }

    void Update()
    {
        if (Time.time >= (FoodTimer + GrowthSpeed) && Food.Count < Capacity)
            SpawnFood();
    }

    private void SpawnFood()
    {
        GameObject go = Instantiate(PrefabManager.Instance.Fruit);
        go.transform.position = SpawningPoints[SpawningIndex].position;
        SpawningIndex = (SpawningIndex + 1) % SpawningPoints.Length;
        go.transform.SetParent(FoodContainer.transform);
        Food.Add(go);
        FoodTimer = Time.time;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (SpawningPoints != null && SpawningPoints.Length > 0)
            foreach (var point in SpawningPoints)
            {
                Gizmos.DrawWireSphere(point.position, 0.25f);
            }
    }

    private void DropFood()
    {
        if (Food.Count > 0)
        {
            FoodBehaviour food = Food[0].GetComponent<FoodBehaviour>();
            Food.RemoveAt(0);
            food.Drop();
        }
    }

    public void OnClick(Vector3 hit)
    {
        DropFood();
    }
}
