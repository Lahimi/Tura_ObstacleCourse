using UnityEngine;
using TMPro;

public class Scorer : MonoBehaviour
{
    public int hits = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] AudioSource hitAudioSource;

    void Start()
    {
        UpdateScoreUI();
    }

    void OnCollisionEnter(Collision obstacle)
    {
        // Check if object is valid to score
        if (obstacle.gameObject.tag != "Hit" && obstacle.gameObject.tag != "Ground")
        {
            hits++;
            UpdateScoreUI();

            // Play collision sound
            if (hitAudioSource != null)
            {
                hitAudioSource.PlayOneShot(hitAudioSource.clip);
            }

            // Tag object as "Hit" so it doesn't count again
            obstacle.gameObject.tag = "Hit";

            Debug.Log($"Scored: {hits} | {gameObject.name} has hit {obstacle.gameObject.name}");
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Hits: {hits}";
        }
    }
}