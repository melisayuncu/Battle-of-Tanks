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
}
