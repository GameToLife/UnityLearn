using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AirKeyBoardControl : KeyBoardControl {

    public AirPlane airPlane;

    void Start() 
    {
      
        
    }

  

    protected override void ActionUpdate()
    {
        
    }

    protected override void GetAKeyDown()
    {
        airPlane.TurnLeftFly();

    }

    protected override void GetSKeyDown()
    {
        
    }

    protected override void GetDKeyDown()
    {
        airPlane.TurnRightFly();
    }

    protected override void GetWKeyDown()
    {
        
    }

    protected override void NoKeyDown()
    {
        airPlane.InitAirFly();
    }


}

