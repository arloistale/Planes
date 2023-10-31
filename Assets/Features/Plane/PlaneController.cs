using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class PlaneController : MonoBehaviour
{
    public float maxThrust = 50f;
    public float responsiveness = 10f;

    [SerializeField]
    private bool isMain = false;

    public bool IsMain
    {
        get
        {
            return isMain;
        }
    }

    private float roll = 0f;
    private float pitch = 0f;
    private float yaw = 0f;

    private float throttle = 0f;

    public float Throttle
    {
        get
        {
            return throttle;
        }
    }

    private float responseModifier 
    { 
        get 
        { 
            return rb.mass / 10f * responsiveness; 
        }
    }

    private Rigidbody rb;

    public Vector3 GetVelocity()
    {
        return rb.velocity;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void SetThrottle(float value)
    {
        throttle = value;
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
        float thrust = maxThrust * throttle;
        rb.AddForce(transform.forward * thrust);
        
        rb.AddTorque(transform.up * yaw * responseModifier);
        rb.AddTorque(transform.right * pitch * responseModifier);
        rb.AddTorque(-transform.forward * roll * responseModifier);
    }
}
