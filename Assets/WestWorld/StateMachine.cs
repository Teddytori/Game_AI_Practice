using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T> where T : BaseGameEntity
{
    private T owner;
    public State<T> curState { get; set; }
    public State<T> prevState { get; set; }
    public State<T> globalState { get; set; }

    public StateMachine(T owner)
    {
        this.owner = owner;
        curState = null;
        prevState = null;
        globalState = null;
    }

    public void Update()
    {
        globalState?.Execute(owner);
        curState?.Execute(owner);
    }

    public void ChangeState(State<T> newState)
    {
        if (newState == null)
        {
            throw new System.Exception("Cannot Change to null state");
        }

        prevState = curState;
        curState.Exit(owner);
        curState = newState;
        curState.Enter(owner);
    }

    public void ReturnToPrevState()
    {
        ChangeState(prevState);
    }

    public bool IsInState(in State<T> targetState)
    {
        return curState == targetState;
    }
}
