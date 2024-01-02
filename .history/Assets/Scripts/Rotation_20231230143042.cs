using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretRotation : MonoBehaviour
{
    public float rotationSpeed = 5f; // Adjust the speed of rotation
    public float rotationClamp = 60f; // Adjust the maximum rotation angle

    private float currentRotation = 0f;

    // Update is called once per frame
    void Update()
    {
        RotateWithMouse();
    }

    void RotateWithMouse()
    {
        float mouseX = Input.GetAxis("Mouse X");

        // Calculate the desired rotation based on mouse input
        float desiredRotation = currentRotation + mouseX * rotationSpeed;

        // Clamp the rotation to the specified range
        desiredRotation = Mathf.Clamp(desiredRotation, -rotationClamp, rotationClamp);

        // Smoothly interpolate towards the desired rotation
        currentRotation = Mathf.Lerp(currentRotation, desiredRotation, Time.deltaTime * rotationSpeed);

        // Apply the rotation to the turret
        transform.localRotation = Quaternion.Euler(0f, currentRotation, 0f);
    }
}
