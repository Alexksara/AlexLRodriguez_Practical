using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private TextMeshProUGUI m_scoreText;
    [SerializeField] private TextMeshProUGUI m_highScoreText;
    [SerializeField] private int m_maxScore = 300;
    [SerializeField] private int m_highScore = 0;
    private int m_currentScore;

    private const string highScorePrefName = "High Score";
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        m_scoreText.text = "Score: " + m_currentScore;
        m_highScoreText.text = "HighScore : " + PlayerPrefs.GetInt(highScorePrefName);
    }

    public void AddScore(int score)
    {
        m_currentScore += score;
        m_scoreText.text = "Score: " + m_currentScore;

        if (m_currentScore >= m_maxScore)
        {
            GameManager.Instance.PlayerVictory();
        }
        if(m_currentScore > m_highScore)
        {
            PlayerPrefs.SetInt(highScorePrefName, m_currentScore);
        }
        m_highScoreText.text = "HighScore : " + PlayerPrefs.GetInt(highScorePrefName);
        
    }
}
