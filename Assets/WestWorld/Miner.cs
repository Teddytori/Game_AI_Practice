using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : BaseGameEntity
{
    private const int ComfortLevel = 5;
    private const int MaxNuggets = 3;
    private const int ThirstLevel = 5;
    private const int TirednessThreshold = 5;

    public WestWorldLocation CurLocation { get; private set; }
    
    private State<Miner> currentState;
    private int goldCarried;
    private int moneyInBank;
    private int thirst;
    private int fatigue;

    public Miner(int val) : base(val)
    {
        currentState = null;
        CurLocation = WestWorldLocation.None;
        goldCarried = 0;
        moneyInBank = 0;
        thirst = 0;
        fatigue = 0;
    }

    public void Update()
    {
        thirst += 1;

        if (currentState != null)
            currentState.Execute(this);
    }

    public void ChangeState(State<Miner> nextState)
    {
        if(nextState == null)
        {
            Debug.LogError("State cannot be null");
            return;
        }

        if (currentState != null)
            currentState.Exit(this);

        currentState = nextState;
        currentState.Enter(this);
    }

    public void AddToGoldCarried(int amount)
    {
        goldCarried += amount;

        if (goldCarried < 0) goldCarried = 0;
    }

    public bool IsPocketsFull()
    {
        return goldCarried >= MaxNuggets;
    }

    public void PutMoneyInBank(int amount)
    {
        moneyInBank += amount;

        if (moneyInBank < 0) moneyInBank = 0;
    }

    public bool IsThirsty()
    {
        return thirst >= ThirstLevel;
    }

    public bool IsTired()
    {
        return fatigue >= TirednessThreshold;
    }

    public void IncreaseFatigue()
    {
        fatigue++;
    }

    public void ChangeLocation(WestWorldLocation destination)
    {
        CurLocation = destination;
    }
}
