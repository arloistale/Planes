using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;  // Target to follow (your airplane)
    public Vector3 offset;  // Offset from the target
    public float smoothTime = 0.3f;  // Time to smooth position
    public float rotationSmoothTime = 0.3f;  // Time to smooth rotation

    private Vector3 velocity;  // Velocity for SmoothDamp

    void FixedUpdate()
    {
        // Compute desired position in world coordinates based on target's local coordinate
        Vector3 desiredPosition = target.TransformPoint(offset);

        // Smoothly move to the desired position
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);

        // Update the position
        transform.position = smoothedPosition;

        // Compute desired rotation
        Quaternion desiredRotation = Quaternion.LookRotation(target.position - transform.position, target.forward);

        // Smoothly rotate to the desired rotation
        Quaternion smoothedRotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSmoothTime);

        // Update the rotation
        transform.rotation = smoothedRotation;
    }
}
