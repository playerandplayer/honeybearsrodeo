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
        
        horizontalRotation += rotationSpeed * Input.GetAxis("Mouse X");
        verticalRotation -= rotationSpeed * Input.GetAxis("Mouse Y");
        
        verticalRotation = Mathf.Clamp(verticalRotation, -90.0f, 90.0f);
        
        transform.rotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0.0f);
        
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");

        Vector3 forwardDirection = transform.forward;
        Vector3 rightDirection = transform.right;

        forwardDirection.y = 0.0f;
        rightDirection.y = 0.0f;
        forwardDirection.Normalize();
        rightDirection.Normalize();
        
        transform.position += (forwardDirection * verticalMovement + rightDirection * horizontalMovement) * moveSpeed * Time.deltaTime;
    }
}

