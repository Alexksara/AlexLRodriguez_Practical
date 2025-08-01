using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour
{


    [SerializeField] private int minEnemyNumber = 4;
    [SerializeField] private int maxEnemyNumber = 8;

    [SerializeField] private float minWaveTime = 8;
    [SerializeField] private float maxWaveTime = 20;
    [SerializeField] private float countdown = 0;

    [SerializeField] private GameObject player;
    [SerializeField] private List<Transform> spawnPoints;
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private List<GameObject> spawnedEnemies;
    
    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if(countdown <= 0 )
        {
            countdown = Mathf.CeilToInt(Random.Range( minWaveTime, maxWaveTime ));
            SpawnWave();
        }
    }

    public void SpawnWave()
    {
        int enemyNumber = Random.Range(minEnemyNumber, maxEnemyNumber);
        
        for (int i = 0; i < enemyNumber; i++)
        {
            Vector3 spawnPosition = spawnPoints[(Random.Range(0, spawnPoints.Count))].transform.position;

            GameObject enemyInstance = Instantiate(enemyPrefabs[(Random.Range(0, enemyPrefabs.Count))], spawnPosition, Quaternion.identity);
            enemyInstance.GetComponent<Enemy>().Initialize(player);
            spawnedEnemies.Add(enemyInstance);

        }
    }

    public void ClearEnemies()
    {
        foreach(GameObject enemy in spawnedEnemies)
        {
            Destroy(enemy);
        }
        spawnedEnemies = null;
    }
}
