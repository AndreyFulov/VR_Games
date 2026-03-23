using UnityEngine;

public class BookDamage : MonoBehaviour
{
    public int damageAmount = 10; // Урон от книги
    private bool hasDealtDamage = false; // Чтобы урон наносился один раз

    private void OnTriggerEnter(Collider other)
    {
        if (!hasDealtDamage && other.CompareTag("Target"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                hasDealtDamage = true;
                
                Destroy(gameObject);
                WaveManager waveManager = FindObjectOfType<WaveManager>();
                waveManager.OnBookDeath();
            }
        }
    }
}
