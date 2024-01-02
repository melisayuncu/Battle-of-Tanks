using System.Collections;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private bool hasCausedDamage = false;

    private bool shouldamage = true;
    public int damage = 1;

    public GameObject explosionPrefab;
    public AudioSource explosionAudio;
    public ParticleSystem explosionParticles;

    void Start()
    {
        explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
        explosionAudio = explosionParticles.GetComponent<AudioSource>();
        explosionParticles.gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision col)
    {
        // Check if the collided object is an enemy
        if (!hasCausedDamage && !shouldamage && col.gameObject.CompareTag("Player"))
        {
            // Apply damage to the player
            PlayerHealth playerHealth = col.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);

                // Play explosion effect
                explosionParticles.transform.position = transform.position;
                explosionParticles.gameObject.SetActive(true);
                explosionParticles.Play();
                explosionAudio.Play();

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
            if(col.gameObject.CompareTag("Ground")){
                                StartCoroutine(DelayedDestroy(0.001f));

            }
            else{
            Debug.Log("Collision with non-player object.");
            }
        }
    }

    IEnumerator DelayedDestroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
