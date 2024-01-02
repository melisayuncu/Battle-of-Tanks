using System.Collections;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private bool hasCausedDamage = false;

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
                explosionAudio.Play();

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

    IEnumerator DelayedDestroy(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
