using UnityEngine;

public class Follow : MonoBehaviour
{
    public float movementSpeed = 5f; // Adjust the speed of movement

    // Update is called once per frame
    void Update()
    {
        MoveCrosshairWithKeys();
    }

    void MoveCrosshairWithKeys()
    {
        // Get the input for Q and E keys
        float moveInput = Input.GetAxis("Horizontal");

        // Calculate the desired horizontal position based on key input
        float desiredX = transform.position.x + moveInput * movementSpeed * Time.deltaTime;

        // Apply the movement to the crosshair
        transform.position = new Vector3(desiredX, transform.position.y, transform.position.z);
    }
}
