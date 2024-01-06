using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : MonoBehaviour
{
    // Prefab of the bullet to be shot
    public GameObject bulletPrefab;

    // Force applied to the bullet when shot
    public float bulletForce = 25.0f;

    // Update is called once per frame
    void Update()
    {
        // Check for the left mouse button or the Space key
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
        {
            // Call the Shoot method when the fire button is pressed
            Shoot();
        }
    }

    // instantiate and shoot a bullet
    void Shoot()
    {
        // Get the spawn position as the tank's current position
        Vector3 spawnPosition = transform.position;

        // Get the spawn rotation as the tank's current rotation
        Quaternion spawnRotation = transform.rotation;

        // Get the local forward direction of the tank and apply bullet force
        Vector3 localXDirection = transform.TransformDirection(Vector3.forward);
        Vector3 velocity = localXDirection * bulletForce;

        // Instantiate a bullet at the calculated position and rotation
        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, spawnRotation);

        // Get the Rigidbody component of the bullet and set its velocity
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = velocity;
    }
}
