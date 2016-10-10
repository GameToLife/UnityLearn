using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
    public EasyJoystick MyJoystick;
    float MoveSpeed = 0.05f;
    float RotSpeed = 0.5f;
    public GameObject WaterB;
    // Use this for initialization
    void Start()
    {
        WaterB.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (MyJoystick.JoystickTouch.x > 0.5f) {
            transform.Rotate(0, RotSpeed, 0);
            Circle.addSpeed = true;
            
        }
        if (MyJoystick.JoystickTouch.x < -0.5f)
        {
            transform.Rotate(0, -RotSpeed, 0);
            Circle.addSpeed = true;
        }
        if (MyJoystick.JoystickTouch.y > 0.5f)
        {
            WaterB.SetActive(true);
            transform.Translate(0, 0, MoveSpeed);
            Circle.addSpeed = true;
        }
        if (MyJoystick.JoystickTouch.y < -0.5f)
        {
            transform.Translate(0, 0, -MoveSpeed); 
            Circle.addSpeed = true;
        }
        if (MyJoystick.JoystickTouch.x == 0 && MyJoystick.JoystickTouch.y==0)
        {
            WaterB.SetActive(false);
            Circle.minusSpeed = true;
        }
    }
}
