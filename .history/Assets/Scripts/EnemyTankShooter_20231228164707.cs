using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTankShooter : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletForce = 20.0f;
    public int damage = 1;
    public float shootInterval = 2.0f; // Adjust this value based on your game's design

public Vector3 bulletSpawnYOffset = new Vector3(0, 0, 0,6); // offset of the bullet to spawn point NEW LINE

    private Transform player;
    private NavMeshAgent navMeshAgent;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();

        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component not found on the enemy tank.");
            enabled = false; // Disable this script to avoid further errors
        }

        StartCoroutine(ShootAtPlayer());
    }
    //  StartFollowingPlayer();

    void Update()
    {
        // Continuously update the destination to follow the player
        if (navMeshAgent != null && navMeshAgent.isActiveAndEnabled && navMeshAgent.isOnNavMesh)
        {
            StartFollowingPlayer();
        }
    }
    void StartFollowingPlayer()
    {
        if (player != null && navMeshAgent != null)
        {
            // Check if the destination is different to avoid recalculating the path unnecessarily
            if (navMeshAgent.destination != player.position)
            {
                navMeshAgent.SetDestination(player.position);
            }
        }
    }
    IEnumerator ShootAtPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval);

            if (player != null)
            {
                // Calculate direction to the player
                Vector3 directionToPlayer = (player.position - transform.position).normalized;

                // Rotate the tank to face the player (optional)
                transform.forward = directionToPlayer;

                // Shoot a bullet in the direction of the player
                GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
                bulletRb.velocity = directionToPlayer * bulletForce;

                // Apply damage to the player (uncomment if needed)
                // PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
                // if (playerHealth != null)
                // {
                //     playerHealth.TakeDamage(damage);
                // }
            }
        }
    }
     
}
