using UnityEngine;

public class Follow : MonoBehaviour
{
    public float followSpeed = 10f; // Adjust the speed of following

    // Update is called once per frame
    void Update()
    {
        FollowMouse();
    }

    void FollowMouse()
    {
        // Get the mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Make sure the z-coordinate is zero

        // Smoothly interpolate towards the mouse position
        transform.position = Vector3.Lerp(transform.position, mousePosition, Time.deltaTime * followSpeed);

        // Rotate the crosshair based on the mouse movement
        float mouseX = Input.GetAxis("Mouse X");
        float rotationAmount = mouseX * followSpeed;
        transform.Rotate(Vector3.forward, -rotationAmount);
    }
}
