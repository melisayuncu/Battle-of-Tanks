using System.Collections;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] m_SpawnPoints;
    public GameObject m_EnemyPrefab;
    public int maxEnemies = 8; // Maximum number of enemies to spawn

    private int currentEnemyCount = 0;
    private int nextSpawnPointIndex = 0;

    void Start()
    {
        SpawnAllEnemies();
        StartCoroutine(SpawnNewEnemiesRoutine());
    }

    void OnEnable()
    {
        EnemyHealth.onEnemyKilled += SpawnNewEnemy;
    }

    void SpawnAllEnemies()
    {
        if (m_EnemyPrefab != null)
        {
            for (int i = 0; i < maxEnemies && i < m_SpawnPoints.Length; i++)
            {
                Instantiate(m_EnemyPrefab, m_SpawnPoints[i].position, Quaternion.identity);
                currentEnemyCount++;
            }
        }
    }

    void SpawnNewEnemy()
    {
        if (m_EnemyPrefab != null && currentEnemyCount < maxEnemies)
        {
            if (nextSpawnPointIndex >= m_SpawnPoints.Length)
            {
                nextSpawnPointIndex = 0; // Reset to the first spawn point if we reach the end
            }

            Instantiate(m_EnemyPrefab, m_SpawnPoints[nextSpawnPointIndex].position, Quaternion.identity);
            currentEnemyCount++;
            nextSpawnPointIndex++;
        }
    }

    IEnumerator SpawnNewEnemiesRoutine()
    {
        while (currentEnemyCount < maxEnemies)
        {
            yield return new WaitForSeconds(2f); // Wait for 2 seconds before spawning a new enemy
            SpawnNewEnemy();
        }
    }
}
