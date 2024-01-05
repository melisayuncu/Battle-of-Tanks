using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // Array of spawn points where enemies will be instantiated
    public Transform[] m_SpawnPoints;

    // Reference to the enemy prefab
    public GameObject m_EnemyPrefab;

    // Maximum number of enemies to spawn
    public int maxEnemies = 10;

    // Current count of spawned enemies
    private int currentEnemyCount = 0;

    void Start()
    {
        // Spawn initial set of enemies when the game starts
        SpawnAllEnemies();
    }

    void OnEnable()
    {
        // Subscribe the SpawnSingleTank method to the onEnemyKilled event
        EnemyHealth.onEnemyKilled += SpawnSingleTank;

        // Subscribe a lambda expression to the onEnemyKilled event to decrement the enemy count
        EnemyHealth.onEnemyKilled += () => currentEnemyCount--;
    }

    // Method to spawn all enemies at the start of the game
    void SpawnAllEnemies()
    {
        // Check if the enemy prefab is assigned
        if (m_EnemyPrefab != null)
        {
            // Instantiate enemies at each spawn point
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
        if (currentEnemyCount < maxEnemies && m_EnemyPrefab != null)
        {
            // Choose a random spawn point
            Transform spawnPoint = m_SpawnPoints[Random.Range(0, m_SpawnPoints.Length)];

            // Instantiate the enemy prefab at the chosen spawn point
            Instantiate(m_EnemyPrefab, spawnPoint.position, Quaternion.identity);

            // Increment the current enemy count
            currentEnemyCount++;
        }
    }
}
