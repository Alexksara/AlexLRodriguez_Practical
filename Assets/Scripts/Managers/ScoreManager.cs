using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

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

    private void Start()
    {
        scoreText.text = "Score: " + currentScore;
        highScoreText.text = "HighScore : " + PlayerPrefs.GetInt(highScorePrefName);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        scoreText.text = "Score: " + currentScore;

        if (currentScore >= maxScore)
        {
            GameManager.Instance.PlayerVictory();
        }
        if(currentScore > highScore)
        {
            PlayerPrefs.SetInt(highScorePrefName, currentScore);
        }
        highScoreText.text = "HighScore : " + PlayerPrefs.GetInt(highScorePrefName);
        
    }
}
