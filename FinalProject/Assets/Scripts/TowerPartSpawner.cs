using UnityEngine;

public class TowerPartSpawner : MonoBehaviour
{
    public GameObject partPrefab;
    public float checkRadius = 0.5f;
    public int details = 20;
    private GameObject currentPart;

    void Start()
    {
        SpawnPart();
    }

    void Update()
    {
        if (currentPart != null)
        {
            float distance = Vector3.Distance(transform.position, currentPart.transform.position);
            if (distance > checkRadius)
            {
                currentPart = null;
                SpawnPart();
            }
        }
    }

    void SpawnPart()
    {
        if (details == 0) return;
        details--;
        if (partPrefab == null) return;
        currentPart = Instantiate(partPrefab, transform.position, transform.rotation);
        Debug.Log("PartSpawned");
    }
}