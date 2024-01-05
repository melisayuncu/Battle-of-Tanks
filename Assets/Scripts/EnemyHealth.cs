using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Score variables
    public int lastScore; // Holds the last score when the enemy dies
    public int maxHealth = 5; // Maximum health of the enemy
    private int currentHealth; // Current health of the enemy

    // Explosion effect variables
    public GameObject explosionPrefab; // Prefab for the explosion effect
    public AudioSource explosionAudio; // Audio source for the explosion sound
    public ParticleSystem explosionParticles; // Particle system for the explosion visual effect

    // Event for when an enemy is killed
    public delegate void EnemyKilled();
    public static event EnemyKilled onEnemyKilled;

    void Start()
    {
        // Initialize health
        currentHealth = maxHealth;

        // Initialize explosion components
        explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
        explosionAudio = explosionParticles.GetComponent<AudioSource>();
        explosionParticles.gameObject.SetActive(false); // Set explosion particles to inactive initially
    }

    // Function to apply damage to the enemy
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Check if the enemy's health is depleted
        if (currentHealth <= 0)
        {
            Die(); // Call the function to handle the enemy's death
        }
    }

    // Function to handle the enemy's death
    void Die()
    {
        // Check if the enemy object exists
        if (gameObject != null)
        {
            // Play explosion effect
            explosionParticles.transform.position = transform.position;
            explosionParticles.gameObject.SetActive(true);
            explosionParticles.Play();
            explosionAudio.Play();

            // Wait for a delay before destroying the enemy
            StartCoroutine(DelayedDestroy(0.001f));

            // Increase the player's score
            Debug.Log("Enemy has died!");
            Score.scorecount += 10;
            lastScore = Score.scorecount;

            // Save the last score to PlayerPrefs for persistence
            PlayerPrefs.SetInt("LastScore", lastScore);
            PlayerPrefs.Save();
        }

        // Notify subscribers that an enemy has been killed
        if (onEnemyKilled != null)
        {
            onEnemyKilled();
        }
    }

    // Coroutine for delayed destruction of the enemy object
    IEnumerator DelayedDestroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
