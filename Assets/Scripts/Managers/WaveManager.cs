using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private int M_minEnemyNumber = 4;
    [SerializeField] private int M_maxEnemyNumber = 8;

    [SerializeField] private float M_minWaveTime = 8;
    [SerializeField] private float M_maxWaveTime = 20;
    private float countdown = 0;

    [SerializeField] private GameObject M_bossEnemy;
    [SerializeField] private GameObject M_player;
    [SerializeField] private List<Transform> M_spawnPoints;
    [SerializeField] private List<GameObject> M_enemyPrefabs;
    [SerializeField] private List<GameObject> M_spawnedEnemies;
    
    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if(countdown <= 0 )
        {
            countdown = Mathf.CeilToInt(Random.Range( M_minWaveTime, M_maxWaveTime ));
            SpawnWave();
        }
    }

    public void SpawnWave()
    {
        int enemyNumber = Random.Range(M_minEnemyNumber, M_maxEnemyNumber);
        
        for (int i = 0; i < enemyNumber; i++)
        {
            Vector3 spawnPosition = M_spawnPoints[(Random.Range(0, M_spawnPoints.Count))].transform.position;

            GameObject enemyInstance = Instantiate(M_enemyPrefabs[(Random.Range(0, M_enemyPrefabs.Count))], spawnPosition, Quaternion.identity);
            M_spawnedEnemies.Add(enemyInstance);
            enemyInstance.GetComponent<Enemy>().Initialize(M_player);

        }
    }

    public void ClearEnemies()
    {
        foreach(GameObject enemy in M_spawnedEnemies)
        {
            Destroy(enemy);
        }
        M_spawnedEnemies = null;
    }

    public void SpawnBoss()
    {
        GameObject bossInstance =  Instantiate(M_bossEnemy, M_spawnPoints[0].transform.position,Quaternion.identity);
        bossInstance.GetComponent<Enemy>().Initialize(M_player);
    }
}
