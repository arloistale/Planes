using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneInput : MonoBehaviour
{
    public PlaneController plane;

    public float throttleIncrement = 0.1f;

    private float throttle = 0f;


    private void Update() 
    {
        float roll = Input.GetAxis("Roll");
        float pitch = -Input.GetAxis("Pitch");
        float yaw = Input.GetAxis("Yaw");

        if (Input.GetKey(KeyCode.Space))
        {
            throttle += throttleIncrement;
        }

        if (Input.GetKey(KeyCode.R))
        {
            throttle -= throttleIncrement;
        }

        throttle = Mathf.Clamp(throttle, 0f, 1f);

        // set plane
        plane.SetRoll(roll);
        plane.SetPitch(pitch);
        plane.SetYaw(yaw);
        plane.SetThrottle(throttle);
    }
}
