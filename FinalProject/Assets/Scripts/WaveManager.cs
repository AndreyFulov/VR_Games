using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public SpawnManager spawnManager;

    private int books = 20;

    private void Start()
    {
        if (spawnManager == null)
        {
            Debug.LogError("WaveManager: не назначен SpawnManager!");
            return;
        }

        StartWaves();
    }

    public void StartWaves()
    {
        WaveOne();
        Invoke(nameof(WaveTwo), 30f);
        Invoke(nameof(WaveThree), 60f);
    }

    private void WaveOne()
    {
        Invoke(nameof(SpawnGray), 1f);
        Invoke(nameof(SpawnGray), 3f);
        Invoke(nameof(SpawnGray), 5f);
        Invoke(nameof(SpawnGreen), 8f);
        Invoke(nameof(SpawnGreen), 10f);
    }

    private void WaveTwo()
    {
        Invoke(nameof(SpawnYellow), 2f);
        Invoke(nameof(SpawnYellow), 5f);
        Invoke(nameof(SpawnGreen), 8f);
        Invoke(nameof(SpawnGreen), 12f);
        Invoke(nameof(SpawnGreen), 16f);
        Invoke(nameof(SpawnRed), 22f);
    }

    private void WaveThree()
    {
        Invoke(nameof(SpawnPurple), 0f);
        Invoke(nameof(SpawnPurple), 15f);
        Invoke(nameof(SpawnRed), 10f);
        Invoke(nameof(SpawnRed), 20f);
        Invoke(nameof(SpawnRed), 25f);
        Invoke(nameof(SpawnGreen), 12f);
        Invoke(nameof(SpawnGreen), 18f);
        Invoke(nameof(SpawnGreen), 24f);
        Invoke(nameof(SpawnGreen), 30f);
    }

    private void SpawnGray() { spawnManager.SpawnEnemy(Color.gray, 1, 1f); }
    private void SpawnGreen() { spawnManager.SpawnEnemy(Color.green, 1, 1.8f); }
    private void SpawnYellow() { spawnManager.SpawnEnemy(Color.yellow, 3, 1f); }
    private void SpawnRed() { spawnManager.SpawnEnemy(Color.red, 3, 1.5f); }
    private void SpawnPurple() { spawnManager.SpawnEnemy(new Color(0.5f, 0f, 0.5f), 5, 0.7f); }

    private void OnDestroy()
    {
    }

    public void OnBookDeath()
    {
        books--;
        Debug.Log("1 book has been killed");
        if (books <= 0)
        {   
            GameManager gameManager = FindObjectOfType<GameManager>();
            gameManager.GameOver();
        }
    }
}