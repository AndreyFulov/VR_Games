using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class LeaderboardManager : MonoBehaviour
{
    public Text leaderboardText;
    public int maxEntries = 10;
    
    private List<LeaderboardEntry> leaderboardEntries = new List<LeaderboardEntry>();
    
    void Start()
    {
        LoadLeaderboard();
        UpdateLeaderboardText();
    }
    
    public void AddEntry(string playerName, float time, int score)
    {
        leaderboardEntries.Add(new LeaderboardEntry
        { 
            playerName = playerName, 
            time = time,
            score = score
        });
        
        leaderboardEntries = leaderboardEntries
            .OrderByDescending(e => e.score)
            .ThenBy(e => e.time)
            .Take(maxEntries)
            .ToList();

        Debug.Log("Сущность сохранена");

        SaveLeaderboard();

        Debug.Log("Обновление таблицы:");
        UpdateLeaderboardText();
    }
    
    void UpdateLeaderboardText()
    {
        if (leaderboardText == null) return;
        
        string text = "Таблица рекордов:\n";
        
        for (int i = 0; i < leaderboardEntries.Count; i++)
        {
            var entry = leaderboardEntries[i];
            int minutes = Mathf.FloorToInt(entry.time / 60f);
            int seconds = Mathf.FloorToInt(entry.time % 60f);
            text += $"{i+1}. {entry.playerName}: {entry.score} очков ({minutes:00}:{seconds:00})\n";
        }
        
        leaderboardText.text = text;
    }

    void SaveLeaderboard()
    {
        LeaderboardData data = new LeaderboardData 
        { 
            entries = leaderboardEntries.Select(e => new LeaderboardEntry
            {
                playerName = e.playerName,
                time = e.time,
                score = e.score
            }).ToList()
        };
        
        string json = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("LeaderboardVR", json);
        PlayerPrefs.Save();
    }
    
    void LoadLeaderboard()
    {
        if (PlayerPrefs.HasKey("LeaderboardVR"))
        {
            string json = PlayerPrefs.GetString("LeaderboardVR");
            LeaderboardData data = JsonUtility.FromJson<LeaderboardData>(json);
            leaderboardEntries = data.entries ?? new List<LeaderboardEntry>();
        }
    }
    
    [System.Serializable]
    private class LeaderboardData
    {
        public List<LeaderboardEntry> entries;
    }

    [System.Serializable]
    public class LeaderboardEntry
    {
        public string playerName;
        public float time; // в секундах
        public int score;
    }
}