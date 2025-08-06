using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private WaveManager M_waveManager;
    [SerializeField] private GameObject M_player;

    private void Awake()
    {
        Instance = this;
        Cursor.visible = false;
    }

    public void PlayerDeath()
    {
        M_waveManager.ClearEnemies();
        Debug.Log("YOU LOSE");
        RestartGame();
        //player.transform.position = Vector3.zero + Vector3.up;

    }

    public void PlayerVictory()
    {
        M_waveManager.ClearEnemies();
        M_waveManager.SpawnBoss();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
