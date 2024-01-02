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
        EnemyHealth.onEnemyKilled += SpawnNewEnemiesRoutine();
    }

    void SpawnAllEnemies()
    {
        if (m_EnemyPrefab != null)
        {
            for (int i = 0; i < m_SpawnPoints.Length && currentEnemyCount < maxEnemies; i++)
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
            int randomNumber = Mathf.RoundToInt(Random.Range(0f, m_SpawnPoints.Length - 1));
            Instantiate(m_EnemyPrefab, m_SpawnPoints[randomNumber].position, Quaternion.identity);
            currentEnemyCount++;
        }
    }

    IEnumerator SpawnNewEnemiesRoutine()
    {
        while (true && currentEnemyCount < maxEnemies)
        {
            yield return new WaitForSeconds(2f); // Wait for 4 seconds before spawning a new enemy
            SpawnNewEnemy();
        }
    }
}
