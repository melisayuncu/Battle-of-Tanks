using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private bool hasCausedDamage = false;

    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
                Debug.Log("Enemy damaged!");
                hasCausedDamage = true; // Set the flag to true to indicate that damage has been caused
                Destroy(gameObject);
                

            }
            else
            {
                Debug.LogError("EnemyHealth component not found on the collided object.");
            }

            // Destroy the bullet
           // Destroy(gameObject);
        }
        else
        {
            Debug.Log("Collision with non-enemy object.");
        }
    }
}
