using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 1;
    private Vector3 direction;
    
    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }
    
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Book"))
        {
            BookHealth health = other.GetComponent<BookHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}