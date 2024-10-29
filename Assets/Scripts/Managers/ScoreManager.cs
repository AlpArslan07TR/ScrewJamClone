using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; } // Singleton eri�im noktas�

    private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText; // TMP referans�

    private void Awake()
    {
        // Singleton �rne�i olu�turulmas�
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Sahne ge�i�lerinde yok olmamas� i�in
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }
}
