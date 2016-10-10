using UnityEngine;
using System.Collections;

public class Circle : MonoBehaviour {
    float CirSpeed;
    float minSpeed = -1;
    float maxSpeed = -10;
    public static bool addSpeed;
    public static bool minusSpeed;
    bool Add = true;
    bool Minus = true;
    float TimeA;
    float TimeM;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(CirSpeed, 0, 0);
        if (addSpeed)
        {
            if (Add)
            {
                TimeA = Time.time;
                Add = false;
            }
            CirSpeed = Mathf.Lerp(minSpeed, maxSpeed, Time.time - TimeA);
            if (CirSpeed == maxSpeed)
            {
                addSpeed = false;
            }
        }
        else
        {
            Add = true;
        }
        if (minusSpeed)
        {
            if (Minus)
            {
                TimeM = Time.time;
                Minus = false;
            }
            CirSpeed = Mathf.Lerp(maxSpeed, minSpeed, Time.time - TimeM);
            if (CirSpeed == minSpeed)
            {
                minusSpeed = false;
            }
        }
        else
        {
            Minus = true;
        }
	}
}
