using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T> where T : BaseGameEntity
{
    private T owner;
    private State<T> curState;
    private State<T> prevState;
    private State<T> globalState;

    public StateMachine(T owner)
    {
        this.owner = owner;

    }
}
