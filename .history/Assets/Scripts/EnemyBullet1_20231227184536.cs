using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
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
        if (!hasCausedDamage && col.gameObject.CompareTag("Player"))
        {
            // Apply damage to the enemy
           
            PlayerHealth playerHealth = col.gameObject.GetComponent<PlayerHealth>();
                if (playerHealth != null)
                {
                     playerHealth.TakeDamage(damage);
                     Debug.Log("p damaged!");
                     hasCausedDamage = true; // Set the flag to true to indicate that damage has been caused
                     Destroy(gameObject);
                }
                else
            {
                Debug.LogError("phealth component not found on the collided object.");
            }
            // Destroy the bullet
           // Destroy(gameObject);
        }
        else
        {
            Debug.Log("Collision with non-p object.");
        }
    }
}
