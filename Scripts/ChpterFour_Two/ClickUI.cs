using UnityEngine;
using System.Collections;

public class ClickUI : UIBase {

    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GameCenter.instance.testRotation.transform.Rotate(Vector3.left, 5.5f, Space.World);
	}

    public void StartTest() 
    {


        
    }

    
}
