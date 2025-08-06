using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private WaveManager m_waveManager;
    [SerializeField] private GameObject m_player;

    private void Awake()
    {
        Instance = this;
        Cursor.visible = false;
    }

    public void PlayerDeath()
    {
        m_waveManager.ClearEnemies();
        Debug.Log("YOU LOSE");
        RestartGame();
        //player.transform.position = Vector3.zero + Vector3.up;

    }

    public void PlayerVictory()
    {
        m_waveManager.ClearEnemies();
        m_waveManager.SpawnBoss();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
