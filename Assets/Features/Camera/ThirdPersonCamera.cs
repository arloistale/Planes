using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;

    /// <summary>
    /// How far off the camera should aim to be from the target.
    /// </summary>
    public Vector3 offset;

    /// <summary>
    /// How far off the camera should look from the target.
    /// </summary>
    public Vector3 lookOffset;

    public float followSpeed = 10;
    public float lookSpeed = 10;

    private Vector3 upVector = Vector3.up;

    private void FixedUpdate()
    {
        UpdatePosition();
        UpdateRotation();
    }

    private void UpdatePosition() 
    {
        Vector3 desiredPosition = target.position + target.forward * offset.z + target.up * offset.y;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * followSpeed);
    }

    private void UpdateRotation()
    {
        Vector3 directionToTarget = target.position - transform.position + target.up * lookOffset.y;

        // this is needed to avoid gimbal lock problems
        upVector = Vector3.Slerp(upVector, target.up, Time.deltaTime * lookSpeed);

        Quaternion desiredRotation = Quaternion.LookRotation(directionToTarget, upVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * lookSpeed);
    }
}
