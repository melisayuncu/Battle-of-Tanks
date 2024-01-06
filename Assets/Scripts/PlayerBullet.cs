using System.Collections;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private bool hasCausedDamage = false;
    // Setting damage value to 1
    public int damage = 1;

    
    public GameObject explosionPrefab;
    public AudioSource explosionAudio;
    public ParticleSystem explosionParticles;

    // Start method
    void Start()
    {
        // Explosion's audio and particules
        explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
        explosionAudio = explosionParticles.GetComponent<AudioSource>();
        explosionParticles.gameObject.SetActive(false);
    }
    
    // Method to check the collisions
    void OnCollisionEnter(Collision col)
    {
        // Check if the collided object is an enemy
        if (!hasCausedDamage && col.gameObject.CompareTag("Enemy"))
        {
            // Apply damage to the enemy
            EnemyHealth enemyHealth = col.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);

                // Play explosion effect
                explosionParticles.transform.position = transform.position;
                explosionParticles.gameObject.SetActive(true);
                explosionParticles.Play();
                // Check if explosionAudio is not null before trying to play it
                if (explosionAudio != null)
                {
                    explosionAudio.Play();
                }

                // Wait for a delay before destroying the bullet
                StartCoroutine(DelayedDestroy(0.001f));

                hasCausedDamage = true; // Set the flag to true to indicate that damage has been caused
            }
            else
            {
                Debug.LogError("EnemyHealth component not found on the collided object.");
            }
        }
        else
        {
            Debug.Log("Collision with non-enemy object.");
        }
    }

    // Delayed destroy method
    IEnumerator DelayedDestroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
