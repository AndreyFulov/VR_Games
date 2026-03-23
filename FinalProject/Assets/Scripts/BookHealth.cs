using UnityEngine;

public class BookHealth : MonoBehaviour
{
    private int currentHealth;
    private float scoreMultiplier;
    private GameManager gameManager;

    public void SetHealthAndScore(int health, float score)
    {
        currentHealth = health;
        scoreMultiplier = score;
        gameManager = FindObjectOfType<GameManager>();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            gameManager.score += (int)(100 * scoreMultiplier);
            Debug.Log($"Текущий счет: {gameManager.score}");
            Destroy(gameObject);
            WaveManager waveManager = FindObjectOfType<WaveManager>();
            waveManager.OnBookDeath();
        }
    }
}