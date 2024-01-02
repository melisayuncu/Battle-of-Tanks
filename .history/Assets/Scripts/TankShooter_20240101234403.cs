using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooter : MonoBehaviour
{
   // public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 25.0f;
    
    //private Transform enemy;
    void Start(){

    }
    void Update()
    {
        // Check for the left mouse button
        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Space"))
        {
            Shoot();
        }
    }

    

    void Shoot()
    {
        
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
