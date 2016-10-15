using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

    public GameObject cube;
    public GameObject sphere;
    public GameObject cylinder;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log(ray);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                AfterHit(hit);
            }
            else
            {
                Debug.Log("hit is not out");
            }
        }


	}


    void AfterHit(RaycastHit hit) 
    {
        if (Transform.Equals(hit.transform,cube.transform))
        {
            Debug.Log("is cube");
        }
        else if (Transform.Equals(hit.transform, sphere.transform))
        {
            Debug.Log("is sphere");
        }
        else if (Transform.Equals(hit.transform, cylinder.transform))
        {
            Debug.Log("is cylinder");
        }
        else
        {
            Debug.Log(hit.transform.name);
        }
    }
}
