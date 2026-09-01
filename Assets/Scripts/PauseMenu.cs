using UnityEngine;
using TMPro;
using System.IO;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuUI;
    [SerializeField] TextMeshProUGUI leaderboardText;
    bool isPaused = false;

    void Start()
    {
        Debug.Log("JSON File Folder: " + Application.persistentDataPath);
        
        if (pauseMenuUI != null)
        {
            pauseMenuUI.SetActive(false); // Keeps UI hidden at start
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) ResumeGame();
            else PauseGame();
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        LoadAndDisplayLeaderboard();
    }

    void LoadAndDisplayLeaderboard()
    {
        string path = Application.persistentDataPath + "/leaderboard.json";
        if (File.Exists(path))
        {
            string jsonString = File.ReadAllText(path);
            ScoreList scoreList = JsonUtility.FromJson<ScoreList>(jsonString);

            string displayOutput = "--- LEADERBOARD (FEWEST HITS) ---\n\n";
            int rank = 1;

            foreach (var s in scoreList.scores)
            {
                displayOutput += $"#{rank} {s.playerName}: {s.obstacleHits} Hits\n";
                rank++;
            }

            if (leaderboardText != null)
            {
                leaderboardText.text = displayOutput;
            }
        }
        else
        {
            if (leaderboardText != null)
            {
                leaderboardText.text = "No scores recorded yet!";
            }
        }
    }
}