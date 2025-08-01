using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private WaveManager M_waveManager;
    [SerializeField] private GameObject M_player;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayerDeath()
    {
        M_waveManager.ClearEnemies();
        Debug.Log("YOU LOSE");
        SceneManager.LoadScene(0);
        //player.transform.position = Vector3.zero + Vector3.up;

    }

    public void PlayerVictory()
    {
        M_waveManager.ClearEnemies();
    }
}
