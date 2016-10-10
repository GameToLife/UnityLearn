using UnityEngine;
using System.Collections;

public class IgnCollision : MonoBehaviour {
    public Transform ballA;
    public Transform ballB;
    public Transform ballC;

	void Start () {
        Physics.IgnoreCollision(ballA.GetComponent<Collider>(),ballC.GetComponent<Collider>());
        Physics.IgnoreCollision(ballB.GetComponent<Collider>(), ballC.GetComponent<Collider>());
	
	}
}
