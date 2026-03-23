using UnityEngine;

public class BallSpawn : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnPoint;
    public float checkRadius;
    public float spawnDelay = 2f;
    
    private bool isSpawning = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        checkRadius = ((SphereCollider)ballPrefab.GetComponent<Collider>()).radius*100;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsBallInSpawnArea() && !isSpawning)
        {
            isSpawning = true;
            Invoke("SpawnBall", spawnDelay);
        }
    }

    bool IsBallInSpawnArea()
    {
        Collider[] colliders = Physics.OverlapSphere(spawnPoint.position, checkRadius);
        return colliders.Length > 0;
    }
    
    void SpawnBall()
    {
        Instantiate(ballPrefab, spawnPoint.position, Quaternion.identity);
        isSpawning = false;
    }
}
