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
        // Create a ray from the camera to the mouse cursor position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Get the direction from the turret position to the hit point
            Vector3 targetDirection = hit.point - transform.position;
            targetDirection.y = 0; // Ensure the turret stays level with the ground

            // Calculate the desired rotation based on the direction
            Quaternion lookRotation = Quaternion.LookRotation(targetDirection);

            // Smoothly interpolate towards the desired rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);

            // Extract the Y rotation to limit it within the specified range
            float clampedYRotation = Mathf.Clamp(transform.localEulerAngles.y, -rotationClamp, rotationClamp);

            // Apply the rotation to the turret
            transform.localRotation = Quaternion.Euler(0f, clampedYRotation, 0f);
        }
    }
}
