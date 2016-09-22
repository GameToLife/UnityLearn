using UnityEngine;
using System.Collections;

public class AirPlane :MonoBehaviour{

    public float speed = 50;

    private float rotationz = 0.0f;         //绕Z轴的旋转量
    public float rotateSpeed_AxisZ = 45f;   //绕Z轴的旋转速度

    private StateMachine fsm;
    private InitAirState initState;
    private TurnRightState turnRightState;
    private TurnLeftState turnLeftState;

	// Use this for initialization
	void Start () 
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
        initState = new InitAirState(fsm, this);
        turnRightState = new TurnRightState(fsm, this);
        turnLeftState = new TurnLeftState(fsm, this);

        initState.AddTransitionStateID(turnRightState.StateID);
        initState.AddTransitionStateID(turnLeftState.StateID);

        turnRightState.AddTransitionStateID(initState.StateID);
        turnRightState.AddTransitionStateID(turnLeftState.StateID);

        turnLeftState.AddTransitionStateID(initState.StateID);
        turnLeftState.AddTransitionStateID(turnRightState.StateID);

    }


    public void InitAirFly() 
    {
        fsm.TransitionStateAction(initState);
    }

    public void TurnRightFly()
    {
        Debug.Log("TurnRightFly");
        fsm.TransitionStateAction(turnRightState);
    }

    public void TurnLeftFly()
    {
        Debug.Log("TurnLeftFly");
        fsm.TransitionStateAction(turnLeftState);
    }
}


public class InitAirState :State
{
    protected AirPlane airPlane;

    public InitAirState(StateMachine _fsm,AirPlane _airPlane) 
    {
        StateID = _fsm.ProdectNewStateID;
        _fsm.AddState(this);
        airPlane = _airPlane;
    }

    public override void Excute()
    {
        airPlane.transform.Translate(new Vector3(0, 0, airPlane.speed / 20 * Time.deltaTime));//向前移动
    }
}


public class TurnRightState : State
{
    protected AirPlane airPlane;

    public TurnRightState(StateMachine _fsm, AirPlane _airPlane)
    {
        StateID = _fsm.ProdectNewStateID;
        _fsm.AddState(this);
        airPlane = _airPlane;
    }

    public override void Excute()
    {
        Debug.Log("TurnRightState");
        airPlane.transform.Rotate(new Vector3(0, 0, (Time.deltaTime * -airPlane.rotateSpeed_AxisZ)), Space.Self);
    }
}


public class TurnLeftState : State
{
    protected AirPlane airPlane;

    public TurnLeftState(StateMachine _fsm, AirPlane _airPlane)
    {
        StateID = _fsm.ProdectNewStateID;
        _fsm.AddState(this);
        airPlane = _airPlane;
    }

    public override void Excute()
    {

        airPlane.transform.Rotate(new Vector3(0, 0, (Time.deltaTime * airPlane.rotateSpeed_AxisZ)), Space.Self);
    }
}
