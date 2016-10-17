using UnityEngine;
using System.Collections;

public class LeafLookAtCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject[] leaf = GameObject.FindGameObjectsWithTag ("Leaf");
		for (int i=0; i<leaf.Length; i++) {
			leaf[i].transform.LookAt(this.transform);		
		
		}

	}
}
