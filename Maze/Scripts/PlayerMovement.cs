using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float sensitivity = 1.0f; 

    public Joystick Joystick;
    public Slider sensitivitySlider; 

    void Start()
    {
        //  initial sensitivity value based on the slider's starting value
        SetSensitivity(sensitivitySlider.value);
        sensitivitySlider.onValueChanged.AddListener(SetSensitivity);
    }

    void Update()
    {
        float joystickHorizontalMove = Joystick.Horizontal;
        float joystickVerticalMove = Joystick.Vertical;

        // Calculating movement dir based on joystick input
        Vector3 movement = new Vector3(joystickHorizontalMove, 0.0f, joystickVerticalMove);
        movement.Normalize();

        //  sensitivity
        movement *= sensitivity;

        
        transform.Translate(movement * speed * Time.deltaTime);
    }
    public void SetSensitivity(float value)
    {
        sensitivity = value;
    }
}
