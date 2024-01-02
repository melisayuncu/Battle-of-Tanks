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
    }

    void SpawnAllEnemies()
    {
        if (m_EnemyPrefab != null)
        {
            foreach (Transform spawnPoint in m_SpawnPoints)
            {
                // Check if the maximum number of enemies has been reached
                if (currentEnemyCount < maxEnemies)
                {
                    Instantiate(m_EnemyPrefab, spawnPoint.position, Quaternion.identity);
                    currentEnemyCount++;
                }
                else
                {
                    break; // Stop spawning if the maximum limit is reached
                }
            }
        }
    }
}
