using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StateMachine{

    

    private List<State> stateList = null;
    protected List<int> stateIDList = null;

    protected State curState;
    public State CurState 
    {
        get 
        {
            if (curState==null)
            {
                Debug.LogError("curState==null");
            }
            return curState;
        }
        protected set 
        {
            curState = value;
        }
    }

    protected int curStateID;
    public int CurStateID 
    {
        get 
        {
            if (curStateID < 0)
            {
                Debug.LogError("curStateID < 0");
            }
           return curStateID;
        }
        set 
        {
            curStateID = value;
        }
    }

    //void fixedupdate()
    //{
    //    if (statelist != null && statelist.count > 0)
    //    {
    //        if (curstate != null)
    //        {
    //            curstate.checktransition();
    //            curstate.excute();
    //        }
    //    }
    //}

    public StateMachine() 
    {
        stateList = new List<State>();
    }

    public void RuningMachine() 
    {
        if (stateList != null && stateList.Count > 0)
        {
            if (CurState != null)
            {
                CurState.CheckTransition();
                CurState.Excute();
            }
        }
    }

    public void AddState(State _state) 
    {
        if (_state==null)
        {
            Debug.LogError("_state==null");
            return;
        }

        //状态机的初始状态
        if (stateList.Count == 0)
        {        
            CurState = _state;
            CurStateID = _state.StateID;
            stateList.Add(_state);
            return;

        }

        if (stateList.Count > 0)
        {
            for (int i = 0; i < stateList.Count; i++)
            {
                if (stateList[i].StateID == _state.StateID)
                {
                    Debug.LogError("the _state had added:" + _state.StateID);
                    return;
                }
            }
        }
        else 
        {
            Debug.LogError("stateList.Count <= 0");
        }

        stateList.Add(_state);

    }

    public void TransitionStateAction(State _state)
    {
        if (_state ==null)
        {
            Debug.LogError("_state ==null");
            return;
        }

        if (stateList.Contains(_state))
        {
            CurState.Exit();
            CurStateID = _state.StateID;
            CurState = _state;
            CurState.Enter();
            
        }
        else
        {
            Debug.LogError("!stateList.Contains(_state)");
        }
    }




    #region 

    
    public int ProdectNewStateID
    {
        get
        {
            if (stateIDList == null)
            {
                stateIDList = new List<int>();
            }
            if (stateIDList.Count > 0)
            {
                int lastID = stateIDList[stateIDList.Count - 1];
                int newID = lastID + 1;
                AddStateID(newID);
                return newID;
            }
            else
            {
                int firstID = 0;
                stateIDList = new List<int>();
                AddStateID(firstID);
                return firstID;
            }
        }
    }

    protected void AddStateID(int _stateID)
    {
        if (!stateIDList.Contains(_stateID))
        {
            stateIDList.Add(_stateID);
        }
        else
        {
            Debug.LogError(_stateID + " :is had add");
        }
    }

    #endregion
}


