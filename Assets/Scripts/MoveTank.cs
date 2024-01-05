using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTank : MonoBehaviour
{
    // Movement speed of the tank
    public float moveSpeed = 5.0f;

    // Rotation speed of the tank
    public float rotationSpeed = 120.0f;

    // Arrays of left and right wheels for wheel rotation
    public GameObject[] leftWheels;
    public GameObject[] rightWheels;

    // Speed of wheel rotation
    public float wheelRotationSpeed = 200.0f;

    // Audio source for tank movement sounds
    public AudioSource movementAudio;

    // Audio clips for engine idling and driving
    public AudioClip engineIdling;
    public AudioClip engineDriving;

    // Pitch range for variation in audio pitch
    public float pitchRange = 0.2f;

    // Reference to the Rigidbody component
    private Rigidbody rb;

    // Input values for movement and rotation
    private float moveInput;
    private float rotationInput;

    // Original pitch of the movement audio
    private float originalPitch;

    void Start()
    {
        // Get the Rigidbody component attached to the tank
        rb = GetComponent<Rigidbody>();

        // Save the original pitch of the movement audio
        originalPitch = movementAudio.pitch;
    }

    void Update()
    {
        // Get input values for movement and rotation
        moveInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Horizontal");

        // rotate wheels based on input
        RotateWheels();

        // Update engine audio based on tank movement
        EngineAudio();
    }

    void FixedUpdate()
    {
        // move the tank based on input
        MoveTankObj(moveInput);

        // Rotate the tank based on input
        RotateTank(rotationInput);
    }

    // move the tank based on input
    void MoveTankObj(float input)
    {
        Vector3 moveDirection = transform.forward * input * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + moveDirection);
    }

    // rotate the tank based on input
    void RotateTank(float input)
    {
        float rotation = input * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0.0f, rotation, 0.0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    // rotate the wheels based on input
    void RotateWheels()
    {
        float wheelRotation = moveInput * wheelRotationSpeed * Time.deltaTime;

        // Rotate the left wheels
        foreach (GameObject wheel in leftWheels)
        {
            if (wheel != null)
            {
                wheel.transform.Rotate(wheelRotation - rotationInput * wheelRotationSpeed * Time.deltaTime, 0.0f, 0.0f);
            }
        }

        // Rotate the right wheels
        foreach (GameObject wheel in rightWheels)
        {
            if (wheel != null)
            {
                wheel.transform.Rotate(wheelRotation + rotationInput * wheelRotationSpeed * Time.deltaTime, 0.0f, 0.0f);
            }
        }
    }

    // control the engine audio based on tank movement
    void EngineAudio()
    {
        // Check if the tank is nearly stationary
        if (Mathf.Abs(moveInput) < 0.1f && Mathf.Abs(rotationInput) < 0.1f)
        {
            // Switch to idling sound if not already
            if (movementAudio.clip == engineDriving)
            {
                movementAudio.clip = engineIdling;
                movementAudio.pitch = Random.Range(originalPitch - pitchRange, originalPitch + pitchRange);
                movementAudio.Play();
            }
        }
        else
        {
            // Switch to driving sound if not already
            if (movementAudio.clip == engineIdling)
            {
                movementAudio.clip = engineDriving;
                movementAudio.pitch = Random.Range(originalPitch - pitchRange, originalPitch + pitchRange);
                movementAudio.Play();
            }
        }
    }
}
