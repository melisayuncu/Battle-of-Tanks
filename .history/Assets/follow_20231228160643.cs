using UnityEngine;

public class Follow : MonoBehaviour
{
    public float movementSpeed = 5f; // Adjust the speed of movement

    // Update is called once per frame
    void Update()
    {
        MoveCrosshairWithMouse();
    }

    void MoveCrosshairWithMouse()
    {
        // Get the mouse X position (horizontal movement)
        float mouseX = Input.GetAxis("Mouse X");

        // Calculate the desired horizontal position based on mouse input
        float desiredX = transform.position.x + mouseX * movementSpeed;

        // Apply the movement to the crosshair
        transform.position = new Vector3(desiredX, transform.position.y, transform.position.z);
    }
}
