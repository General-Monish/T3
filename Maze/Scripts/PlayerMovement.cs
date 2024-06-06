using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float sensitivity = 1.0f; // Sensitivity factor

    public Joystick Joystick;
    public Slider sensitivitySlider; // Reference to the UI Slider

    void Start()
    {
        // Set the initial sensitivity value based on the slider's starting value
        SetSensitivity(sensitivitySlider.value);
        // Add a listener to the slider's value change event to update sensitivity dynamically
        sensitivitySlider.onValueChanged.AddListener(SetSensitivity);
    }

    void Update()
    {
        float joystickHorizontalMove = Joystick.Horizontal;
        float joystickVerticalMove = Joystick.Vertical;

        // Calculate movement direction based on joystick input
        Vector3 movement = new Vector3(joystickHorizontalMove, 0.0f, joystickVerticalMove);
        movement.Normalize();

        // Apply sensitivity
        movement *= sensitivity;

        // Apply movement to the player object
        transform.Translate(movement * speed * Time.deltaTime);
    }

    // Method to set the sensitivity based on the slider value
    public void SetSensitivity(float value)
    {
        sensitivity = value;
    }
}
