using UnityEngine;

public class WallTower : MonoBehaviour
{
    public int wallHealth = 10;
    public float breakCooldown = 0.5f;
    public Collider wallCollider;
    
    private float lastDamageTime = 0f;

    void Start()
    {
        if (wallCollider != null)
        {
            wallCollider.enabled = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Book") && Time.time > lastDamageTime + breakCooldown)
        {
            wallHealth--;
            lastDamageTime = Time.time;
            
            if (wallHealth <= 0)
            {
                gameObject.SetActive(false);
                Debug.Log("Wall broken");
            }
        }
    }
}