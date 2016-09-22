using UnityEngine;
using System.Collections;

public class KeyBoardControl : MonoBehaviour {

    protected Transform targetControl;

	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
        ActionUpdate();
        KeyBorardControl();
	}




    void KeyBorardControl() 
    {

        if (Input.anyKey)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                GetWKeyDown();
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                GetAKeyDown();
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                GetSKeyDown();
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                GetDKeyDown();
            }

        }
        else 
        {
            NoKeyDown();
        }

    }

    protected virtual void ActionUpdate() 
    {
        
    }

    protected virtual void GetWKeyDown() 
    {
      //  Debug.logger.Log("KeyCode.W");
    }

    protected virtual void GetAKeyDown()
    {
     //   Debug.logger.Log("KeyCode.A");
    }

    protected virtual void GetSKeyDown()
    {
      //  Debug.logger.Log("KeyCode.S");
    }

    protected virtual void GetDKeyDown()
    {
     //   Debug.logger.Log("KeyCode.D");
    }

    protected virtual void NoKeyDown() 
    {
 
    }
}
