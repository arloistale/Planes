using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneAI : MonoBehaviour
{
    public PlaneController plane;
    public PlaneController targetPlane; 

    /// <summary>
    /// The distance at which the AI attempts to follow.
    /// </summary>
    public float followDistance = 10f; 

    /// <summary>
    ///  Measures the strength of the AI plane's steering response to
    ///  misalignment between the two planes.
    /// </summary>
    public float steeringCoefficient = 0.1f;

    private void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector3 toTarget = targetPlane.transform.position - plane.transform.position;
        AdjustThrottle(toTarget);
        SteerTowardsPlayer(toTarget);
    }

    private void AdjustThrottle(Vector3 toTarget)
    {
        float distanceToTarget = toTarget.magnitude;

        // slow down, speed up based on how close to target
        float value = (distanceToTarget - followDistance) / 5f;
        float throttle = Mathf.Clamp01(value);
  
        plane.SetThrottle(throttle);
    }

    private void SteerTowardsPlayer(Vector3 toTarget)
    {
        float distanceToTarget = toTarget.magnitude;
        Vector3 directionToTarget = toTarget.normalized;

        // Calculate the differences in all axes and respond by steering
        float deltaYaw = Vector3.SignedAngle(plane.transform.forward, directionToTarget, plane.transform.up);
        float deltaPitch = Vector3.SignedAngle(plane.transform.forward, directionToTarget, plane.transform.right); 
        float deltaRoll = Vector3.SignedAngle(plane.transform.up, directionToTarget, plane.transform.forward);

        deltaYaw *= steeringCoefficient;
        deltaPitch *= steeringCoefficient;
        deltaRoll *= steeringCoefficient;

        plane.SetYaw(deltaYaw);
        plane.SetPitch(deltaPitch);
        plane.SetRoll(deltaRoll);
    }

}
