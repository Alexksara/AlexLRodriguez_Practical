using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private WaveManager waveManager;
    [SerializeField] private GameObject player;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayerDeath()
    {
        waveManager.ClearEnemies();
        Debug.Log("YOU LOSE");
        SceneManager.LoadScene(0);
        //player.transform.position = Vector3.zero + Vector3.up;

    }

    public void PlayerVictory()
    {
        waveManager.ClearEnemies();
    }
}
