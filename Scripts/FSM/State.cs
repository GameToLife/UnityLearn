using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class State{

  //  private Dictionary<int, int> transitionDic = new Dictionary<int, int>();

    private List<int> transitionStateIDList = new List<int>();

    private int stateID = -1;
    public int StateID 
    {
        get 
        {
            return stateID;
        }
        set 
        {
            stateID = value;
        }
    }


    public void AddTransitionStateID(int _stateID) 
    {
        if (_stateID <0)
        {
            Debug.LogError("_stateID <0");
            return;
        }

        if (transitionStateIDList.Contains(_stateID))
        {
            Debug.LogError("transitionStateIDList.Contains(_stateID)");
            return;
        }

        transitionStateIDList.Add(_stateID);
    }


    public virtual void Enter() 
    {
 
    }


    public virtual void Excute() 
    {
 
    }


    public virtual void Exit() 
    {
 
    }
}
