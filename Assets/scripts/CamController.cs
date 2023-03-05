using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5.0f;
    [SerializeField] private float moveSpeed = 10.0f;

    private float horizontalRotation = 0.0f;
    private float verticalRotation = 0.0f;

    void Update()
    {
        // Get mouse input for rotation
        horizontalRotation += rotationSpeed * Input.GetAxis("Mouse X");
        verticalRotation -= rotationSpeed * Input.GetAxis("Mouse Y");

        // Clamp vertical rotation to prevent camera from flipping upside down
        verticalRotation = Mathf.Clamp(verticalRotation, -90.0f, 90.0f);

        // Apply rotation to camera
        transform.rotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0.0f);

        // Get keyboard input for movement
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        // Calculate movement direction based on camera rotation
        Vector3 forwardDirection = transform.forward;
        Vector3 rightDirection = transform.right;

        forwardDirection.y = 0.0f;
        rightDirection.y = 0.0f;

        forwardDirection.Normalize();
        rightDirection.Normalize();

        // Apply movement to camera position
        transform.position += (forwardDirection * verticalMovement + rightDirection * horizontalMovement) * moveSpeed * Time.deltaTime;
    }
}

