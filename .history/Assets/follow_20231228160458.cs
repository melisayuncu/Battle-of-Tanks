using UnityEngine;

public class FollowRotation : MonoBehaviour
{
    public float rotationSpeed = 5f; // Adjust the speed of rotation

    // Update is called once per frame
    void Update()
    {
        RotateCrosshairWithMouse();
    }

    void RotateCrosshairWithMouse()
    {
        // Get the mouse X position (horizontal movement)
        float mouseX = Input.GetAxis("Mouse X");

        // Calculate the desired rotation based on mouse input
        float desiredRotation = transform.localEulerAngles.z - mouseX * rotationSpeed;

        // Apply the rotation to the crosshair
        transform.localRotation = Quaternion.Euler(0f, 0f, desiredRotation);
    }
}
