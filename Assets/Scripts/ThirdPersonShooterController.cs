using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine; 
public class ThirdPersonShooterController : MonoBehaviour
{
    // Cinemachine cameras for the tank
    private CinemachineVirtualCamera tankFollowCamera;
    private CinemachineVirtualCamera tankAimCamera;

    void Start()
    {
        // Find the cameras by their names
        tankFollowCamera = GameObject.Find("TankFollowCamera").GetComponent<CinemachineVirtualCamera>();
        tankAimCamera = GameObject.Find("TankAimCamera").GetComponent<CinemachineVirtualCamera>();

        // Ensure only the follow camera is active initially
        if (tankFollowCamera != null)
            tankFollowCamera.gameObject.SetActive(true);

        if (tankAimCamera != null)
            tankAimCamera.gameObject.SetActive(false);
    }

    void Update()
{
        // Check for the right mouse button or the Z key
        if (Input.GetMouseButtonDown(1) || Input.GetButtonDown("Submit") && Input.GetKeyDown(KeyCode.Z))
        {
        // Toggle between cameras
        ToggleCameras();
    }
}


    void ToggleCameras()
    {
        // Ensure cameras are not null
        if (tankFollowCamera != null && tankAimCamera != null)
        {
            // Toggle the active state of cameras
            tankFollowCamera.gameObject.SetActive(!tankFollowCamera.gameObject.activeSelf);
            tankAimCamera.gameObject.SetActive(!tankAimCamera.gameObject.activeSelf);
        }
    }



    
}
