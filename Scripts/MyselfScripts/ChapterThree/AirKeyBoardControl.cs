using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AirKeyBoardControl : KeyBoardControl {

    int branch = 0;

    void Start() 
    {
      
        
    }

  

    protected override void ActionUpdate()
    {
        
    }

    protected override void GetAKeyDown()
    {
        //Debug.Log("GetAKeyDown");
        //targetControl.Rotate(new Vector3(0, 0, (Time.deltaTime * rotateSpeed_AxisZ)), Space.Self);
    }

    protected override void GetSKeyDown()
    {
        
    }

    protected override void GetDKeyDown()
    {
        //targetControl.Rotate(new Vector3(0, 0, (Time.deltaTime * -rotateSpeed_AxisZ)), Space.Self);
    }

    protected override void GetWKeyDown()
    {
        
    }

    protected override void NoKeyDown()
    {
        BackToBalance();
    }


    protected void BackToBalance() 
    {
 
    }
}

