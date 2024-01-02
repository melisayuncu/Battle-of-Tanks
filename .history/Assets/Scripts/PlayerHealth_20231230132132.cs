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
        // Add any game over logic here (e.g., restart the level, show game over screen)
        Debug.Log("Player has died!");

        explosionParticles.transform.position = transform.position;
        explosionParticles.gameObject.SetActive(true);
        explosionParticles.Play();
        explosionAudio.Play();

        StartCoroutine(MyCoroutine(3f));

    }

    IEnumerator MyCoroutine(float delay)
    {
        // Wait for the explosion duration
        yield return new WaitForSeconds(explosionParticles.main.duration);

        // Hide the player object
        gameObject.SetActive(false);

        // Wait for an additional 1 second
        yield return new WaitForSeconds(1f);

        // Load the game loading scene
        SceneManager.LoadScene("GameOver"); // Replace 2 with the actual build index or scene name for the game loading scene
    }
}
