using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Vector3[] m_SpawnPoints = new Vector3[4] { new Vector3(8.30000019f, -55.7000008f, -13.0600004f), new Vector3(-37.7999992f, -0.77700001f, -38.0999985f), new Vector3(-32.7400017f, 0.335000008f, 34.6920013f), new Vector3(41.3199997f, 0.899999976f, -20.1000004f) };
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
