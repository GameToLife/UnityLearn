using UnityEngine;
using System.Collections;

public class KeyBoardControl : MonoBehaviour {

    protected Transform targetControl =null;
    protected Vector3 directions;
    protected Transform referenceObj =null;

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
            if (referenceObj ==null)
            {
                referenceObj = GameCenter.instance.mainCamera.transform;
            }
            directions = Vector2.zero;
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
            MoveDirection();
        }
        else 
        {
            NoKeyDown();
        }

    }

    protected virtual void MoveDirection() 
    {

    }

    protected virtual void ActionUpdate() 
    {
        
    }

    protected virtual void GetWKeyDown() 
    {
      //  Debug.logger.Log("KeyCode.W");
        directions += referenceObj.forward;
    }

    protected virtual void GetAKeyDown()
    {
     //   Debug.logger.Log("KeyCode.A");
        directions -= referenceObj.forward;
    }

    protected virtual void GetSKeyDown()
    {
      //  Debug.logger.Log("KeyCode.S");
        directions -= referenceObj.right;
    }

    protected virtual void GetDKeyDown()
    {
     //   Debug.logger.Log("KeyCode.D");
        directions += referenceObj.right;
    }

    protected virtual void NoKeyDown() 
    {
 
    }
}
