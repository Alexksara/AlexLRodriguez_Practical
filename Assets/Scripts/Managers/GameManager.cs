using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private WaveManager waveManager;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayerDeath()
    {
        waveManager.ClearEnemies();
        Debug.Log("YOU LOSE");
        SceneManager.SetActiveScene(SceneManager.GetActiveScene());

    }

    public void PlayerVictory()
    {
        waveManager.ClearEnemies();
    }
}
