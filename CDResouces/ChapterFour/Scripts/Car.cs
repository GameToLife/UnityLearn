using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour {
    public WheelCollider FLCollider;
    public WheelCollider FRCollider;

    public EasyJoystick myJoystick;

    public float maxTorque = 500;
    public float maxAngle = 20;
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().centerOfMass = new Vector3(0, -0.8f, 0);
	}
	void FixedUpdate () {
        FLCollider.motorTorque = maxTorque * myJoystick.JoystickTouch.y;
        FLCollider.steerAngle = maxAngle * myJoystick.JoystickTouch.x;
        FRCollider.motorTorque = maxTorque * myJoystick.JoystickTouch.y;
        FRCollider.steerAngle = maxAngle * myJoystick.JoystickTouch.x; 
	}
}
