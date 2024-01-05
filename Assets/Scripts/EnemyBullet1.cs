using System.Collections;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private bool hasCausedDamage = false;

    public int damage = 1;

    // Prefabs and components for explosion effects
    public GameObject explosionPrefab;
    public AudioSource explosionAudio;
    public ParticleSystem explosionParticles;

    void Start()
    {
        // Instantiate explosion particles and get references to audio and particle components
        explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
        explosionAudio = explosionParticles.GetComponent<AudioSource>();
        explosionParticles.gameObject.SetActive(false); // Deactivate explosion particles initially
    }

    void OnCollisionEnter(Collision col)
    {
        // Check if the bullet has already caused damage to avoid double damage
        if (!hasCausedDamage && col.gameObject.CompareTag("Player"))
        {
            // Apply damage to the player
            PlayerHealth playerHealth = col.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Take damage and trigger explosion effects
                playerHealth.TakeDamage(damage);
                PlayExplosionEffects();

                // Wait for a delay before destroying the bullet
                StartCoroutine(DelayedDestroy(0.001f));

                hasCausedDamage = true; // Set the flag to true to indicate that damage has been caused
            }
            else
            {
                Debug.LogError("PlayerHealth component not found on the collided object.");
            }
        }
        else
        {
            // Handle collision with non-player objects (e.g., floor)
            if (col.gameObject.CompareTag("Floor"))
            {
                // Wait for a delay before destroying the bullet
                StartCoroutine(DelayedDestroy(0.5f));
            }
            else
            {
                Debug.Log("Collision with non-player object.");
            }
        }
    }

    // Play explosion effects and audio
    void PlayExplosionEffects()
    {
        explosionParticles.transform.position = transform.position;
        explosionParticles.gameObject.SetActive(true);
        explosionParticles.Play();
        if (explosionAudio != null)
        {
            explosionAudio.Play();
        }
    }

    // Coroutine for delayed destruction of the bullet
    IEnumerator DelayedDestroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
