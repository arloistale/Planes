using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneInput : MonoBehaviour
{
    public PlaneController plane;
    public PlaneWeapons planeWeapons;

    public float throttleIncrement = 0.1f;

    private float throttle = 0f;


    private void Update() 
    {
        HandleMovementInput();
        HandleWeaponsInput();
    }

    private void HandleWeaponsInput()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            planeWeapons.Fire();
        }
    }

    private void HandleMovementInput()
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

        throttle = Mathf.Clamp01(throttle);

        // set plane
        plane.SetRoll(roll);
        plane.SetPitch(pitch);
        plane.SetYaw(yaw);
        plane.SetThrottle(throttle);
    }
}
