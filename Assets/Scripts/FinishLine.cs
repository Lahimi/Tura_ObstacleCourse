using UnityEngine;
using UnityEngine.SceneManagement; // Required for reloading the scene
using TMPro;
using System.IO;
using System.Collections.Generic;
using System.Linq;

[System.Serializable]
public class PlayerScore
{
    public string playerName;
    public int obstacleHits;
}

[System.Serializable]
public class ScoreList
{
    public List<PlayerScore> scores = new List<PlayerScore>();
}

public class FinishLine : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] GameObject victoryPanel;
    [SerializeField] TMP_InputField nameInputField;

    int savedHits = 0;

    void Start()
    {
        if (victoryPanel != null)
        {
            victoryPanel.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Scorer playerScorer = other.GetComponent<Scorer>();

            if (playerScorer != null)
            {
                savedHits = playerScorer.hits; // Capture hit count from Scorer script
            }

            if (victoryPanel != null)
            {
                victoryPanel.SetActive(true);
                Time.timeScale = 0f; // Freeze game physics and timer
            }
        }
    }

    // Assign this to your Submit Button's OnClick event
    public void SubmitNameAndSave()
    {
        string enteredName = nameInputField.text;

        // Default to "Anonymous" if the input field is left empty
        if (string.IsNullOrEmpty(enteredName))
        {
            enteredName = "Anonymous";
        }

        // Save score to JSON
        SaveScore(enteredName, savedHits);

        // ALWAYS unfreeze time before switching or reloading scenes
        Time.timeScale = 1f;

        // Reload the current scene to reset player position, obstacles, and triggers
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void SaveScore(string name, int hits)
    {
        PlayerScore newScore = new PlayerScore { playerName = name, obstacleHits = hits };

        string path = Application.persistentDataPath + "/leaderboard.json";
        ScoreList scoreList = new ScoreList();

        // Read existing JSON scores if file exists
        if (File.Exists(path))
        {
            string jsonString = File.ReadAllText(path);
            scoreList = JsonUtility.FromJson<ScoreList>(jsonString);
        }

        // Add current entry
        scoreList.scores.Add(newScore);

        // Sort score list ascending (lowest hit counts placed at top)
        scoreList.scores = scoreList.scores.OrderBy(s => s.obstacleHits).ToList();

        // Write updated list back to JSON file
        string updatedJson = JsonUtility.ToJson(scoreList, true);
        File.WriteAllText(path, updatedJson);
    }
}