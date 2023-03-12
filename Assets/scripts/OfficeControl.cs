using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeControl : MonoBehaviour
{
    public float rotateSpeed = 1f;

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput != 0)
        {
            transform.Rotate(Vector3.up, horizontalInput * rotateSpeed);
        }
    }
}

