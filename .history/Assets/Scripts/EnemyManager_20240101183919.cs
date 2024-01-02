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
        EnemyHealth.onEnemyKilled += HandleEnemyKilled;
    }

    void SpawnAllEnemies()
    {
        for (int i = 0; i < maxEnemies; i++)
        {
            SpawnSingleTank();
        }
    }

    void SpawnSingleTank()
    {
        // Check if the total number of enemies is less than the maximum limit
        if (currentEnemyCount < 10 && m_EnemyPrefab != null)
        {
            // Choose a random spawn point
            Transform spawnPoint = m_SpawnPoints[Random.Range(0, m_SpawnPoints.Length)];
            Instantiate(m_EnemyPrefab, spawnPoint.position, Quaternion.identity);
            currentEnemyCount++;
        }
    }

    void HandleEnemyKilled()
    {
        currentEnemyCount--;

        // Check if all enemies are killed
        if (currentEnemyCount <= 0)
        {
            StartCoroutine(RespawnAfterDelay(2.0f)); // Adjust the delay as needed
        }
    }

    IEnumerator RespawnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnSingleTank();
    }
}
