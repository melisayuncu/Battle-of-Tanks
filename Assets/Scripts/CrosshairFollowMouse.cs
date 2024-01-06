using UnityEngine;

public class CrosshairFollowMouse : MonoBehaviour
{
    // To adjust the speed of following
    public float followSpeed = 10f; 

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
    }
}
