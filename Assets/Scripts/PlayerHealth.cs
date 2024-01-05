using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Maximum health of the player
    public int maxHealth = 10;

    // Current health of the player
    private int currentHealth;

    // Reference to the healthbar
    public Slider healthSlider;

    // Prefab and components for explosion effects
    public GameObject explosionPrefab;
    public AudioSource explosionAudio;
    public ParticleSystem explosionParticles;

    // Flag to ensure game over logic is triggered only once
    private bool hasDied = false;

    // Instantiate explosion particles on awake
    void Awake()
    {
        explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
        explosionAudio = explosionParticles.GetComponent<AudioSource>();
        explosionParticles.gameObject.SetActive(false);
    }

    // Initialize player health
    void Start()
    {
        currentHealth = maxHealth;

        // Set the initial health value on the slider
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    // apply damage to the player
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Update the healthbae
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        // Check if player's health is zero or below to trigger death
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // handle player death
    void Die()
    {
        Debug.Log("Player has died!");

        // Trigger game over logic only once
        if (!hasDied)
        {
            hasDied = true;

            // Play explosion effect
            explosionParticles.transform.position = transform.position;
            explosionParticles.gameObject.SetActive(true);
            explosionParticles.Play();
            explosionAudio.Play();

            // Wait for a delay before loading the game over scene
            StartCoroutine(DelayedGameOver(0.25f));
        }
    }

    // Coroutine for delayed destruction of the player object
    IEnumerator DelayedDestroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }

    // Coroutine for delayed loading of the game over scene
    IEnumerator DelayedGameOver(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(2);

        // Destroy the player object
        Destroy(gameObject);
    }
}
