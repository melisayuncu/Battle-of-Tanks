using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    public GameObject explosionPrefab;
    public AudioSource explosionAudio;
    public ParticleSystem explosionParticles;

    public delegate void EnemyKilled();
    public static event EnemyKilled onEnemyKilled;

    void Start()
    {
        currentHealth = maxHealth;

        explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
        explosionAudio = explosionParticles.GetComponent<AudioSource>();
        explosionParticles.gameObject.SetActive(false);
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
        if (gameObject != null)
        {
            // Play explosion effect
            explosionParticles.transform.position = transform.position;
            explosionParticles.gameObject.SetActive(true);
            explosionParticles.Play();
            explosionAudio.Play();

            // Wait for a delay before destroying the enemy

            // Add any other death-related logic here
            Debug.Log("Enemy has died!");
            Score.scorecount += 10;
        }

        if (onEnemyKilled != null)
        {
            onEnemyKilled();
        }
    }

    
}
