using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    public delegate void EnemyKilled();
    public static event EnemyKilled onEnemyKilled;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if(gameObject != null)
        {
            // Add any death-related logic here (e.g., play death animation, spawn effects)
            Debug.Log("Enemy has died!");
            Destroy(gameObject); // Destroy the object when it dies
            Score.scorecount +
        }

        if(onEnemyKilled != null)
        {
            onEnemyKilled();
        }
        
    }
}
