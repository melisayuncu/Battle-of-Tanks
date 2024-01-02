using UnityEngine;

public class Follow : MonoBehaviour
{
    public float rotationSpeed = 5f; // Adjust the speed of rotation

    // Update is called once per frame
    void Update()
    {
        RotateWithMouse();
    }

    void RotateWithMouse()
    {
        // Get the mouse X position (horizontal movement)
        float mouseX = Input.GetAxis("Mouse X");

        // Calculate the desired rotation based on mouse input
        float desiredRotation = transform.localEulerAngles.y + mouseX * rotationSpeed;

        // Apply the rotation to the object
        transform.localRotation = Quaternion.Euler(0f, desiredRotation, 0f);
    }
}
