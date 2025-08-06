using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WaveManager : MonoBehaviour
{
    [SerializeField] private int m_minEnemyNumber = 4;
    [SerializeField] private int m_maxEnemyNumber = 8;

    [SerializeField] private float m_minWaveTime = 8;
    [SerializeField] private float m_maxWaveTime = 20;
    private float countdown = 0;

    [SerializeField] private GameObject m_bossEnemy;
    [SerializeField] private GameObject m_player;
    [SerializeField] private List<Transform> m_spawnPoints;
    [SerializeField] private List<GameObject> m_enemyPrefabs;
    [SerializeField] private List<GameObject> m_spawnedEnemies;
    
    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime;

        if(countdown <= 0 )
        {
            countdown = Mathf.CeilToInt(Random.Range( m_minWaveTime, m_maxWaveTime ));
            SpawnWave();
        }
    }

    public void SpawnWave()
    {
        int enemyNumber = Random.Range(m_minEnemyNumber, m_maxEnemyNumber);
        
        for (int i = 0; i < enemyNumber; i++)
        {
            Vector3 spawnPosition = m_spawnPoints[(Random.Range(0, m_spawnPoints.Count))].transform.position;

            GameObject enemyInstance = Instantiate(m_enemyPrefabs[(Random.Range(0, m_enemyPrefabs.Count))], spawnPosition, Quaternion.identity);
            m_spawnedEnemies.Add(enemyInstance);
            enemyInstance.GetComponent<Enemy>().Initialize(m_player);

        }
    }

    public void ClearEnemies()
    {
        foreach(GameObject enemy in m_spawnedEnemies)
        {
            Destroy(enemy);
        }
        m_spawnedEnemies = null;
    }

    public void SpawnBoss()
    {
        GameObject bossInstance =  Instantiate(m_bossEnemy, m_spawnPoints[0].transform.position,Quaternion.identity);
        bossInstance.GetComponent<Enemy>().Initialize(m_player);
    }
}
