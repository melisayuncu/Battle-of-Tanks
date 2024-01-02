using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    public delegate void EnemyKilled();
    public static event EnemyKilled onEnemyKilled;

    public GameObject explosionPrefab;
    private AudioSource explosionAudio;
    private ParticleSystem explosionParticles;

    void Awake()
    {
        explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
        explosionAudio = explosionParticles.GetComponent<AudioSource>();
        explosionParticles.gameObject.SetActive(false);
    }

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
        if (gameObject != null)
        {
            StartCoroutine(ExplodeAfterDelay(0.1f)); // Delay before exploding (adjust as needed)
        }
    }

    IEnumerator ExplodeAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Explode
        explosionParticles.transform.position = transform.position;
        explosionParticles.gameObject.SetActive(true);
        explosionParticles.Play();
        explosionAudio.Play();

        // Destroy the object after the explosion
        yield return new WaitForSeconds(explosionParticles.main.duration);
        Destroy(gameObject);

        // Notify that the enemy was killed
        if (onEnemyKilled != null)
        {
            onEnemyKilled();
        }

        // Delay before transitioning to the game over scene
        yield return new WaitForSeconds(1f);

        // Transition to the game over scene
        SceneManager.LoadScene("GameOverScene"); // Replace "GameOverScene" with the actual scene name
    }
}
