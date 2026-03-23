using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private GameManager gameManager;

    private void Start()
    {
        currentHealth = maxHealth;
        gameManager = FindObjectOfType<GameManager>();
        Debug.Log($"Игрок создан. Здоровье: {currentHealth}/{maxHealth}");
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log($"Игрок получил {damage} урона. Здоровье: {currentHealth}/{maxHealth}");
        
        if (gameManager != null)
        {
            gameManager.score -= 300;
            Debug.Log($"Текущий счет: {gameManager.score}");
        }

        if (currentHealth <= 0)
        {
            Debug.Log("Игрок погиб!");
            currentHealth = 0;

            if (gameManager != null)
            {
                gameManager.GameOver();
            }
        }
    }
}
