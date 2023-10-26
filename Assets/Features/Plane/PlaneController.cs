using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float thrustSpeed = 50.0f;
    public float bankSpeed = 45.0f;
    public float pitchSpeed = 30.0f;
    public float rollSpeed = 60.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Thrust
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * thrustSpeed);
        }

        // Bank (Left and Right)
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(Vector3.down * bankSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(Vector3.up * bankSpeed);
        }

        // Pitch (Up and Down)
        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddTorque(Vector3.left * pitchSpeed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.AddTorque(Vector3.right * pitchSpeed);
        }

        // Roll (Roll Left and Roll Right)
        if (Input.GetKey(KeyCode.Q))
        {
            rb.AddTorque(Vector3.back * rollSpeed);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            rb.AddTorque(Vector3.forward * rollSpeed);
        }
    }
}
