using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private TextMeshProUGUI M_scoreText;
    [SerializeField] private TextMeshProUGUI M_highScoreText;
    [SerializeField] private int M_maxScore = 300;
    [SerializeField] private int M_highScore = 0;
    private int currentScore;

    private const string highScorePrefName = "High Score";
    private void Awake()
    {
        Instance = this;
        currentScore = 290;
    }

    private void Start()
    {
        M_scoreText.text = "Score: " + currentScore;
        M_highScoreText.text = "HighScore : " + PlayerPrefs.GetInt(highScorePrefName);
    }

    public void AddScore(int score)
    {
        currentScore += score;
        M_scoreText.text = "Score: " + currentScore;

        if (currentScore >= M_maxScore)
        {
            GameManager.Instance.PlayerVictory();
        }
        if(currentScore > M_highScore)
        {
            PlayerPrefs.SetInt(highScorePrefName, currentScore);
        }
        M_highScoreText.text = "HighScore : " + PlayerPrefs.GetInt(highScorePrefName);
        
    }
}
