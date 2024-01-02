using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Vector3[] m_SpawnPoints = new Vector3[4] { new Vector3(8.3f, -55.7f, -13.06f), new Vector3(-37.8f, -0.777f, -38.1f), new Vector3(-32.74f, 0.335f, 34.692f), new Vector3(41.32f, 0.9f, -20.1f) };
    public GameObject m_EnemyPrefab;
    public int maxEnemies = 5; // Maximum number of enemies to spawn

    private int currentEnemyCount = 0;

    void Start()
    {
        SpawnAllInitialEnemies();
    }

    void OnEnable()
    {
        EnemyHealth.onEnemyKilled += SpawnNewEnemy;
    }

    void SpawnAllInitialEnemies()
    {
        if (m_EnemyPrefab != null)
        {
            for (int i = 0; i < Mathf.Min(m_SpawnPoints.Length, 4); i++)
            {
                Instantiate(m_EnemyPrefab, m_SpawnPoints[i], Quaternion.identity);
                currentEnemyCount++;
            }
        }
    }

    void SpawnNewEnemy()
    {
        if (m_EnemyPrefab != null && currentEnemyCount < maxEnemies)
        {
            Instantiate(m_EnemyPrefab, m_SpawnPoints[currentEnemyCount % m_SpawnPoints.Length], Quaternion.identity);
            currentEnemyCount++;
        }
    }
}
