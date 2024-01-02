using System.Collections;
using UnityEngine;

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
        if(gameObject != null)
        {
            explosionParticles.transform.position = transform.position;
            explosionParticles.gameObject.SetActive(true);
            explosionParticles.Play();
            explosionAudio.Play();
            // Add any death-related logic here (e.g., play death animation, spawn effects)
            //Debug.Log("Enemy has died!");
            Destroy(gameObject); // Destroy the object when it dies
        }

        if(onEnemyKilled != null)
        {
            onEnemyKilled();
        }
        
    }
}
