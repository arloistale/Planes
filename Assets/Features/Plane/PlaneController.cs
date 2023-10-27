using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float throttleIncrement = 0.1f;
    public float maxThrust = 50f;
    public float responsiveness = 10f;

    private float roll = 0f;
    private float pitch = 0f;
    private float yaw = 0f;

    private float throttle = 0f;

    private float responseModifier 
    { 
        get 
        { 
            return rb.mass / 10f * responsiveness; 
        }
    }

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() 
    {
        roll = Input.GetAxis("Roll");
        pitch = -Input.GetAxis("Pitch");
        yaw = Input.GetAxis("Yaw");

        if (Input.GetKey(KeyCode.Space))
        {
            throttle += throttleIncrement;
        }

        if (Input.GetKey(KeyCode.R))
        {
            throttle -= throttleIncrement;
        }

        throttle = Mathf.Clamp(throttle, 0f, 1f);
    }

    private void FixedUpdate()
    {
        float thrust = maxThrust * throttle;
        
        rb.AddForce(transform.forward * thrust);
        
        rb.AddTorque(transform.up * yaw * responseModifier);
        rb.AddTorque(transform.right * pitch * responseModifier);
        rb.AddTorque(-transform.forward * roll * responseModifier);
    }
}
