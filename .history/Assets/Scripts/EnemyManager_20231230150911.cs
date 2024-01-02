using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] m_SpawnPoints;
    public GameObject m_EnemyPrefab;
    public int maxEnemies = 5; // Maximum number of enemies to spawn

    private int currentEnemyCount = 0;
    private List<Vector3> spawnPositions = new List<Vector3>();

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
            foreach (Transform spawnPoint in m_SpawnPoints)
            {
                spawnPositions.Add(spawnPoint.position);
                Instantiate(m_EnemyPrefab, spawnPoint.position, Quaternion.identity);
            }
        }
    }

    void SpawnNewEnemy()
    {
        if (m_EnemyPrefab != null && currentEnemyCount < maxEnemies)
        {
            int randomNumber = Mathf.RoundToInt(Random.Range(0f, spawnPositions.Count - 1));
            Instantiate(m_EnemyPrefab, spawnPositions[randomNumber], Quaternion.identity);
            currentEnemyCount++;
        }
    }

    void OnDestroy()
    {
        EnemyHealth.onEnemyKilled -= SpawnNewEnemy;
    }
}
