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

    /// <summary>
    /// How far out the plane looks for obstacles.
    /// </summary>
    public float obstacleAvoidanceDistance = 20f;

    /// <summary>
    /// The layer on which the plane raycasts for obstacles.
    /// </summary>
    public LayerMask obstacleLayer; 

    private void Update()
    {
        Vector3 target = targetPlane.transform.position;
        target = ObstacleAvoidance(target);

        Debug.DrawLine(plane.transform.position, target, Color.magenta);

        Vector3 toTarget = target - plane.transform.position;

        AdjustThrottle(toTarget);
        SteerTowardsPlayer(toTarget);
    }
    private Vector3 ObstacleAvoidance(Vector3 target)
    {
        RaycastHit hit;

        Debug.DrawRay(plane.transform.position, plane.transform.forward * obstacleAvoidanceDistance, Color.red);

        if (Physics.Raycast(plane.transform.position, plane.transform.forward, out hit, obstacleAvoidanceDistance, obstacleLayer))
        {
            if (hit.collider.tag != "Player")
            {
                target = plane.transform.position + (plane.transform.position - hit.point).normalized * 50f;
            }
        }

        return target;
    }

    private void AdjustThrottle(Vector3 toTarget)
    {
        float distanceToTarget = toTarget.magnitude;

        if (distanceToTarget < followDistance) {
            plane.SetThrottle(0);
            return;
        }

        float distanceDelta = distanceToTarget - followDistance;
        float throttle = Mathf.Clamp01(1 - Mathf.Exp(-distanceDelta * 0.2f));

        plane.SetThrottle(throttle);
    }

    private void SteerTowardsPlayer(Vector3 toTarget)
    {
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
