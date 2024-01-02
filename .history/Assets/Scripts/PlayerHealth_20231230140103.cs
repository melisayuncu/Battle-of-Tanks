using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    private int currentHealth;
    public Slider healthSlider; // Reference to the health slider (if you have one)

    public GameObject explosionPrefab;
    private AudioSource explosionAudio;
    private ParticleSystem explosionParticles;

    private bool hasDied = false;

    void Start()
    {
        currentHealth = maxHealth;

        // Set the initial health value on the slider
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }

        explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
        explosionAudio = explosionParticles.GetComponent<AudioSource>();
        explosionParticles.gameObject.SetActive(false);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Update the health slider (if you have one)
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

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

            // Wait for a delay before loading the game over scene
            StartCoroutine(DelayedGameOver(0.5f));
        }
    }

    IEnumerator DelayedDestroy(float delay)
    {
        
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
        //StartCoroutine(DelayedGameOver(0.5f));
    
    }

    IEnumerator DelayedGameOver(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(2);

        Destroy(gameObject);
        
    }
}
