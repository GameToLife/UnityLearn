﻿using UnityEngine;
using System.Collections;

public class Catch : MonoBehaviour {


    public float speed = 50;

    private Vector3 turnRoundDirection = Vector3.zero;
    public Vector3 TurnRoundDirection
    {
        get
        {
            return turnRoundDirection;
        }
        protected set
        {
            turnRoundDirection = value;
        }
    }

    private StateMachine fsm;
    private InitCatchState initState;
    private CatchMoveState boatMoveState;




    // Use this for initialization
    void Start()
    {
        InitFSM();
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    void FixedUpdate()
    {

        fsm.RuningMachine();
    }

    void InitFSM()
    {
        fsm = new StateMachine();
        initState = new InitCatchState(fsm, this);
        boatMoveState = new CatchMoveState(fsm, this);



        initState.AddTransitionStateID(boatMoveState.StateID);
        boatMoveState.AddTransitionStateID(initState.StateID);




    }

    public void Move(Vector3 _dir)
    {
        Transform referenceObj = GameCenter.instance.mainCamera.transform;
        Vector3 dir = _dir.y * referenceObj.forward + _dir.x * referenceObj.right;
        dir.y = 0;
        // dir = dir.normalized;
        turnRoundDirection = dir;
        if (turnRoundDirection != Vector3.zero)
        {
            MoveBoat();
        }
        else
        {
            InitBoat();
        }
    }


    public void InitBoat()
    {
        fsm.TransitionStateAction(initState);
    }

    public void MoveBoat()
    {
        fsm.TransitionStateAction(boatMoveState);
    }



    public void StandBy()
    {
        InitBoat();
    }

}

public class InitCatchState : State
{
    protected Catch airPlane;

    public InitCatchState(StateMachine _fsm, Catch _airPlane)
    {
        StateID = _fsm.ProdectNewStateID;
        _fsm.AddState(this);
        airPlane = _airPlane;
    }

    public override void Excute()
    {

        //  airPlane.transform.Translate(new Vector3(0, 0, airPlane.speed / 20 * Time.deltaTime));//向前移动
    }
}

public class CatchMoveState : State
{
    protected Catch airPlane;

    public CatchMoveState(StateMachine _fsm, Catch _airPlane)
    {
        StateID = _fsm.ProdectNewStateID;
        _fsm.AddState(this);
        airPlane = _airPlane;
    }

    public override void Excute()
    {
      //  airPlane.transform.Translate(new Vector3(0, 0, airPlane.speed / 20 * Time.deltaTime));//向前移动
        Vector3 dir = airPlane.TurnRoundDirection;
        airPlane.transform.Translate(dir * airPlane.speed / 1000 * Time.deltaTime);
        

        float time = 0.0f;

        if (dir != Vector3.zero)
        {
            Quaternion quat = Quaternion.identity;
            quat.SetLookRotation(dir);
            airPlane.transform.rotation = Quaternion.Slerp(airPlane.transform.rotation, quat, time * Time.deltaTime);
        }
    }
}
