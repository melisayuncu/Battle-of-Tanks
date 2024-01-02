using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : MonoBehaviour
{
   // public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 10.0f;
    
    //private Transform enemy;
    
    void Update()
    {
        // Check for the left mouse button
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    

    void Shoot()
    {
        // Create a bullet at the firePoint position and rotation
        //GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Get the rigidbody of the bullet and apply force forward
       // Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
       /* if (bulletRb != null)
        {
            // Apply force in the forward direction of the firePoint
            bulletRb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
        }

        // Destroy the bullet after a certain time (adjust as needed)
        Destroy(bullet, 2f);*/


        Vector3 spawnPosition = transform.position;
       //Quaternion spawnRotation = Quaternion.identity;
        Quaternion spawnRotation = transform.rotation;
        Vector3 localXDirection = transform.TransformDirection(Vector3.forward);
        Vector3 velocity = localXDirection * bulletForce;

        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, spawnRotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.velocity = velocity;

    }
    
}
