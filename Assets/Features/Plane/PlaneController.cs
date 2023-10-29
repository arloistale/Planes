using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float maxThrust = 50f;
    public float responsiveness = 10f;

    private float roll = 0f;
    private float pitch = 0f;
    private float yaw = 0f;

    private float thrust = 0f;

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

    public void SetThrottle(float throttleValue)
    {
        thrust = maxThrust * throttleValue;
    }

    public void SetRoll(float value)
    {
        roll = value;
    }

    public void SetPitch(float value)
    {
        pitch = value;
    }

    public void SetYaw(float value)
    {
        yaw = value;
    }

    private void FixedUpdate()
    {
        rb.AddForce(transform.forward * thrust);
        
        rb.AddTorque(transform.up * yaw * responseModifier);
        rb.AddTorque(transform.right * pitch * responseModifier);
        rb.AddTorque(-transform.forward * roll * responseModifier);
    }
}
