using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miner : BaseGameEntity
{
    public const int COMFORT_LEVEL = 5;
    public const int MAX_NUGGETS = 3;
    public const int THIRST_LEVEL = 5;
    public const int TIREDNESS_THRESHOLD = 5;

    public int GoldCarried { get; set; }
    public int MoneyInBank { get; private set; }
    public int Thirst { get; private set; }
    public int Fatigue { get; private set; }
    public WestWorldLocation CurLocation { get; private set; }


    public StateMachine<Miner> minerStateMachine { get; private set; }

    public Miner(int val) : base(val)
    {
        CurLocation = WestWorldLocation.None;
        GoldCarried = 0;
        MoneyInBank = 0;
        Thirst = 0;
        Fatigue = 0;

        minerStateMachine = new StateMachine<Miner>(this);
        minerStateMachine.curState = GoHomeAndSleepTilRested.Instance;
    }

    public void Update()
    {
        Thirst += 1;

        minerStateMachine.Update();
    }

    public void AddToGoldCarried(int amount)
    {
        GoldCarried += amount;

        if (GoldCarried < 0) GoldCarried = 0;
    }

    public bool IsPocketsFull()
    {
        return GoldCarried >= MAX_NUGGETS;
    }

    public void PutMoneyToBank(int amount)
    {
        MoneyInBank += amount;

        if (MoneyInBank < 0) MoneyInBank = 0;
    }

    public bool IsThirsty()
    {
        return Thirst >= THIRST_LEVEL;
    }

    public void BuyAndDrinkAWhiskey()
    {
        Thirst = 0;
        MoneyInBank -= 2;
    }

    public bool IsTired()
    {
        return Fatigue >= TIREDNESS_THRESHOLD;
    }

    public void IncreaseFatigue()
    {
        Fatigue++;
    }

    public void DecreaseFatigue()
    {
        Fatigue -= 3;
        if (Fatigue < 0)
            Fatigue = 0;
    }

    public void ChangeLocation(WestWorldLocation destination)
    {
        CurLocation = destination;
    }
}
