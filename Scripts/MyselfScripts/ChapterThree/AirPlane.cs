using UnityEngine;
using System.Collections;

public class AirPlane : State {

    public float speed = 50;

    private float rotationz = 0.0f;         //绕Z轴的旋转量
    public float rotateSpeed_AxisZ = 45f;   //绕Z轴的旋转速度

    private StateMachine fsm;


	// Use this for initialization
	void Start () 
    {
        InitFSM();
	}

    void FixedUpdate()
    {
        fsm.RuningMachine();
    }

    void InitFSM()
    {
        //fsm = new StateMachine();
        //initState = new InitAirState(fsm, this);
        //fsm.AddState(initState);
        //turnRround = new TurnAirRound(fsm, this);
        //fsm.AddState(turnRround);

        //initState.AddTransitionStateID(turnRround.StateID);

        //turnRround.AddTransitionStateID(initState.StateID);

    }

	// Update is called once per frame
	void Update () {
	
	}
}
