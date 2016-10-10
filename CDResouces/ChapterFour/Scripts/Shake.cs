using UnityEngine;
using System.Collections;

public class Shake : MonoBehaviour {
    float RotSpeedX=0.04f;
    float RotSpeedZ=0.06f;
    float ShakeFactor = 4;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (transform.eulerAngles.x >= ShakeFactor && transform.eulerAngles.x <= 180)
            {
                RotSpeedX = -0.04f;
            }
        if (transform.eulerAngles.x <= 360 - ShakeFactor && transform.eulerAngles.x > 180)
            {
                RotSpeedX = 0.04f;
            }
        if (transform.eulerAngles.z >= ShakeFactor && transform.eulerAngles.z <= 180)
            {
                RotSpeedZ = -0.06f;
            }
        if (transform.eulerAngles.z <= 360 - ShakeFactor && transform.eulerAngles.z > 180)
            {
                RotSpeedZ = 0.06f;
            }
            transform.Rotate(RotSpeedX, 0, RotSpeedZ);
	}
}
