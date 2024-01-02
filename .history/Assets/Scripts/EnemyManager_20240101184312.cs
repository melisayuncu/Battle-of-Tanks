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
        EnemyHealth.onEnemyKilled += SpawnSingleTank;
    }

    void SpawnAllEnemies()
    {
        if (m_EnemyPrefab != null)
        {
            foreach (Transform spawnPoint in m_SpawnPoints)
            {
                Instantiate(m_EnemyPrefab, spawnPoint.position, Quaternion.identity);
            }
        }
    }

    // New method to spawn a single tank at one of the spawn points
    void SpawnSingleTank()
    {
        // Check if the total number of enemies is less than the maximum limit
        if (currentEnemyCount < 12 && m_EnemyPrefab != null)
        {
            // Choose a random spawn point
            Transform spawnPoint = m_SpawnPoints[Random.Range(0, m_SpawnPoints.Length)];
            Instantiate(m_EnemyPrefab, spawnPoint.position, Quaternion.identity);
            currentEnemyCount++;
        }
    }
}
