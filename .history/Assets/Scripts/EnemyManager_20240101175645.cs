using System.Collections;
using System.Collections.Generic;
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
    }

    void OnEnable()
    {
        EnemyHealth.onEnemyKilled += SpawnNewEnemy;
    }

    void SpawnAllEnemies()
    {
        if (m_EnemyPrefab != null)
        {
            for (int i = 0; i < m_SpawnPoints.Length && i < maxEnemies; i++)
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
            Instantiate(m_EnemyPrefab, m_SpawnPoints[randomNumber], Quaternion.identity);
            currentEnemyCount++;
        }
    }
}
