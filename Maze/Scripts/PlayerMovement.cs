using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float sensitivity = 1.0f;
    public Joystick Joystick;

    void Update()
    {
        float joystickHorizontalMove = Joystick.Horizontal;
        float joystickVerticalMove = Joystick.Vertical;

        // Calculate movement direction based on joystick input
        Vector3 movement = new Vector3(joystickHorizontalMove, 0.0f, joystickVerticalMove);
        movement.Normalize();

        // Calculate movement magnitude based on joystick input
        float joystickMagnitude = movement.magnitude;

        // Apply movement to the player object
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
