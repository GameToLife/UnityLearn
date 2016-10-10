using UnityEngine;
using System.Collections;

public class Wheel : MonoBehaviour {
    public WheelCollider CPCollider;
    public float CirValue=0;
	// Use this for initialization
	void Start () {
	
	}
	
	void Update () {
        transform.rotation = CPCollider.transform.rotation*Quaternion.Euler(CirValue,CPCollider.steerAngle,0);
        CirValue += CPCollider.rpm * 360 / 60 * Time.deltaTime;
	}
}
