using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnterMineAndDigForNugget : State
{
    private EnterMineAndDigForNugget()
    {
    }

    private static Lazy<EnterMineAndDigForNugget> lazyInstance = new Lazy<EnterMineAndDigForNugget>();
    public static EnterMineAndDigForNugget Instance
    {
        get{ return lazyInstance.Value; }

        private set
        {
            Debug.LogError("Cannot Set Singleton Instance");
        }
    }

    public override void Enter(Miner miner)
    {

    }

    public override void Execute(Miner miner)
    {
        throw new System.NotImplementedException();
    }

    public override void Exit(Miner miner)
    {
        throw new System.NotImplementedException();
    }
}
