using UnityEngine;
using System.Collections;

public class MyCar : MonoBehaviour {

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
    private InitMyCarState initState;
    private MyCarMoveState boatMoveState;




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
        initState = new InitMyCarState(fsm, this);
        boatMoveState = new MyCarMoveState(fsm, this);



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

public class InitMyCarState : State
{
    protected MyCar airPlane;

    public InitMyCarState(StateMachine _fsm, MyCar _airPlane)
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

public class MyCarMoveState : State
{
    protected MyCar airPlane;

    public MyCarMoveState(StateMachine _fsm, MyCar _airPlane)
    {
        StateID = _fsm.ProdectNewStateID;
        _fsm.AddState(this);
        airPlane = _airPlane;
    }

    public override void Excute()
    {
          airPlane.transform.Translate(new Vector3(0, 0, airPlane.speed / 2 * Time.deltaTime));//向前移动
        Vector3 dir = airPlane.TurnRoundDirection;
      //  airPlane.transform.Translate(dir * airPlane.speed / 1000 * Time.deltaTime);


        float time = 0.3f;

        if (dir != Vector3.zero)
        {
            Quaternion quat = Quaternion.identity;
            quat.SetLookRotation(dir);
            airPlane.transform.rotation = Quaternion.Slerp(airPlane.transform.rotation, quat, time * Time.deltaTime);
        }
    }
}

