using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] m_SpawnPoints;
    public GameObject m_EnemyPrefab;
    public int maxEnemies = 8; // Maximum number of enemies to spawn

    private int currentEnemyCount = 0;

    void Start()
    {
        SpawnAllEnemies();
        StartCoroutine(SpawnNewEnemiesRoutine());
    }

    void OnEnable()
    {
    }

    void SpawnAllEnemies()
    {
        if (m_EnemyPrefab != null)
        {
            foreach (Transform spawnPoint in m_SpawnPoints)
            {
                Instantiate(m_EnemyPrefab, spawnPoint.position, Quaternion.identity);
                currentEnemyCount++;
            }
        }
    }
    void SpawnNewEnemy()
    {
        if (m_EnemyPrefab != null)
        {
            foreach (Transform spawnPoint in m_SpawnPoints)
            {
                Instantiate(m_EnemyPrefab, spawnPoint.position, Quaternion.identity);
                currentEnemyCount++;
            }
        }
    }

    

    IEnumerator SpawnNewEnemiesRoutine()
    {
        while (true && currentEnemyCount<maxEnemies)
        {
            yield return new WaitForSeconds(4f); // Wait for 3 seconds before spawning a new enemy
            SpawnNewEnemy();
        }
    }
}
