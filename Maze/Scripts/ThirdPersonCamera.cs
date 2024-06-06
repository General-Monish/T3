using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;   // The sphere (player)
    public Vector3 offset;     // Offset position from the target
    public float smoothSpeed = 0.125f;  // Smooth factor for camera movement

    void LateUpdate()
    {
        // Calculate the desired position
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Make the camera look at the target
        transform.LookAt(target);
    }
}
