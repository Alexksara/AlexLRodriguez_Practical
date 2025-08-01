using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private int maxScore = 300;
    [SerializeField] private int highScore = 0;
    private int currentScore;

    private const string highScorePrefName = "High Score";
    private void Awake()
    {
        Instance = this;
    }

    public void AddScore(int score)
    {
        currentScore += score;
        scoreText.text = "Score: " + score;

        if (score >= maxScore)
        {
            GameManager.Instance.PlayerVictory();
        }
        if(score > highScore)
        {
            PlayerPrefs.SetInt(highScorePrefName, score);
        }
        highScoreText.text = "HighScore : " + PlayerPrefs.GetInt(highScorePrefName);
        
    }
}
