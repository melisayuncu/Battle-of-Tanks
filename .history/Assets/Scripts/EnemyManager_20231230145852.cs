using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] m_SpawnPoints;
    public GameObject m_EnemyPrefab;
    public int maxEnemies = 5; // Maximum number of enemies to spawn

    private int currentEnemyCount = 0;

    void Start()
    {
        SpawnAllEnemies();
        StartContinuousSpawn();

        // Subscribe the OnEnemyKilled method to the onEnemyKilled event
        EnemyHealth.onEnemyKilled += OnEnemyKilled;
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

    void StartContinuousSpawn()
    {
        InvokeRepeating("SpawnNewEnemy", 0f, 5f); // Spawn a new enemy every 5 seconds
    }

    void SpawnNewEnemy()
    {
        if (m_EnemyPrefab != null && currentEnemyCount < maxEnemies)
        {
            int randomNumber = Mathf.RoundToInt(Random.Range(0f, m_SpawnPoints.Length - 1));
            Instantiate(m_EnemyPrefab, m_SpawnPoints[randomNumber].position, Quaternion.identity);
            currentEnemyCount++;
        }
    }

    // This method is called when an enemy is killed
    void OnEnemyKilled()
    {
        currentEnemyCount--; // Decrease the count when an enemy is killed

        // If the count is less than the maximum, spawn a new enemy immediately
        if (currentEnemyCount < maxEnemies)
        {
            int randomNumber = Mathf.RoundToInt(Random.Range(0f, m_SpawnPoints.Length - 1));
            Instantiate(m_EnemyPrefab, m_SpawnPoints[randomNumber].position, Quaternion.identity);
            currentEnemyCount++;
        }
    }
}
