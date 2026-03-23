using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;
    public VRKeyboardManager keyboardManager;
    public LeaderboardManager leaderboardManager;
    public GameObject lostTable;
    public AudioManager audioManager;

    private float gameTimer;
    private bool isGameRunning = true;

    void Start()
    {
        score = 2000;
        gameTimer = 0f;
        StartTimer();
        keyboardManager = FindObjectOfType<VRKeyboardManager>();
    }

    void Update() 
    {
        if (isGameRunning) gameTimer += Time.deltaTime;
    }
    void StartTimer() { isGameRunning = true; }
    void StopTimer() { isGameRunning = false; }


    public void GameOver()
    {
        Debug.Log("=== GAME OVER ===");
        StopTimer();

        // Останавливаем спавн
        SpawnManager spawnManager = FindObjectOfType<SpawnManager>();
        if (spawnManager != null) Destroy(spawnManager.gameObject);
        WaveManager waveManager = FindObjectOfType<WaveManager>();
        if (waveManager != null) Destroy(waveManager.gameObject);

        // Уничтожаем книги
        GameObject[] books = GameObject.FindGameObjectsWithTag("Book");
        foreach (GameObject book in books) Destroy(book);

        if (score <= 3000)
        {
            lostTable.SetActive(true);
            audioManager.PlayLoseSound();
            return;
        }
        else
        {
            audioManager.PlayWinSound();
        }

        // Показываем клавиатуру для ввода имени
        if (keyboardManager != null) 
        {
            keyboardManager.ShowKeyboard();
        }
        else
        {
            Debug.Log("Да где ты бля");
        }
    }

    public void SubmitRecord(string playerName)
    {
        // Дорасчёт очков
        int finalScore = score - Mathf.FloorToInt(gameTimer * 10f);

        if (leaderboardManager != null)
        {
            leaderboardManager.AddEntry(playerName, gameTimer, finalScore);
            Debug.Log($"Рекорд сохранен: {playerName} - {finalScore} очков за {gameTimer:F2} сек.");
        }
        if (keyboardManager != null) 
        {
            keyboardManager.HideKeyboard();
        }
        else
        {
            Debug.Log("Куда пропал KeyboardManager???");
        }
    }
}
