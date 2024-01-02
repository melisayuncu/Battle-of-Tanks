using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] m_SpawnPoints;
    public GameObject m_EnemyPrefab;
    public int maxEnemies = 10; // Maximum number of enemies to spawn

    private int currentEnemyCount = 0;

    void Start()
    {
        SpawnAllEnemies();
    }

    void OnEnable()
    {
        EnemyHealth.onEnemyKilled += SpawnAllEnemies;
        CheckAndSpawnAdditionalEnemies();
    }

    void CheckAndSpawnAdditionalEnemies()
    {
        int enemiesToSpawn = maxEnemies - currentEnemyCount;

        if (enemiesToSpawn > 0)
        {
            for (int i = 0; i < enemiesToSpawn; i++)
            {
                InstantiateEnemy();
            }
        }
    }

    void SpawnAllEnemies()
    {
        if (m_EnemyPrefab != null)
        {
            foreach (Transform spawnPoint in m_SpawnPoints)
            {
                InstantiateEnemy();
            }
        }
    }

    void InstantiateEnemy()
    {
        if (currentEnemyCount < maxEnemies)
        {
            Instantiate(m_EnemyPrefab, GetNextSpawnPoint().position, Quaternion.identity);
            currentEnemyCount++;
        }
    }

    Transform GetNextSpawnPoint()
    {
        int index = currentEnemyCount % m_SpawnPoints.Length;
        return m_SpawnPoints[index];
    }
}
