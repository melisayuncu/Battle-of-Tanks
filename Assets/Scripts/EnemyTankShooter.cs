using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTankShooter : MonoBehaviour
{
    // Reference to the bullet prefab
    public GameObject bulletPrefab;
    public float bulletForce = 20.0f;
    // Amount of damage the bullet does
    public int damage = 1;
    // Time interval between shots
    public float shootInterval = 2.0f;

    // Offset of the bullet spawn point along the Y-axis
    public Vector3 bulletSpawnYOffset = new Vector3(0, 0, 1);

    // Reference to the player's transform
    private Transform player;

    // Reference to the NavMeshAgent component
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        // Find the player's transform based on the "Player" tag
        player = GameObject.FindGameObjectWithTag("Player").transform;

        // Get the NavMeshAgent component attached to the enemy tank
        navMeshAgent = GetComponent<NavMeshAgent>();

        // Check if NavMeshAgent is not found
        if (navMeshAgent == null)
        {
            Debug.LogError("NavMeshAgent component not found on the enemy tank.");
            enabled = false; // Disable this script to avoid further errors
        }

        // Start the coroutine for shooting at the player
        StartCoroutine(ShootAtPlayer());
    }

    void Update()
    {
        // Continuously update the destination to follow the player
        if (navMeshAgent != null && navMeshAgent.isActiveAndEnabled && navMeshAgent.isOnNavMesh)
        {
            StartFollowingPlayer();
        }
    }

    // update the destination to follow the player
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

    // Coroutine for shooting at the player
    IEnumerator ShootAtPlayer()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval);

            if (player != null)
            {
                // Calculate direction to the player
                Vector3 directionToPlayer = (player.position - transform.position).normalized;

                transform.forward = directionToPlayer;

                // Spawn a bullet at the calculated position and rotation
                GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.forward * bulletSpawnYOffset.z, transform.rotation);

                // Get the Rigidbody component of the bullet
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

                // Set the velocity of the bullet in the direction of the player
                bulletRb.velocity = directionToPlayer * bulletForce;

                
            }
        }
    }
}
