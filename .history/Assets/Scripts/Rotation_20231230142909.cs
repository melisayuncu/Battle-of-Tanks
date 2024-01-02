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

        // Get the position of the mouse cursor in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));

        // Calculate the direction from the turret to the mouse cursor
        Vector3 direction = mousePosition - transform.position;

        // Rotate the turret to face the mouse cursor
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }
}
