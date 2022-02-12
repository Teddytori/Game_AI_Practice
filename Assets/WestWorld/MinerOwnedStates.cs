using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnterMineAndDigForNugget : State<Miner>
{
    private EnterMineAndDigForNugget()
    {

    }

    private static EnterMineAndDigForNugget _instance = null;
    public static EnterMineAndDigForNugget Instance
    {
        get
        {
            if (_instance == null)
                _instance = new EnterMineAndDigForNugget();

            return _instance; 
        }
    }

    public override void Enter(Miner miner)
    {
        if(miner.CurLocation != WestWorldLocation.Goldmine)
        {
            miner.WriteLog("Walking to gold mine");
            miner.ChangeLocation(WestWorldLocation.Goldmine);
        }
    }

    public override void Execute(Miner miner)
    {
        miner.AddToGoldCarried(1);
        miner.IncreaseFatigue();
        miner.WriteLog("Picking up a nugget");
        if (miner.IsPocketsFull())
        {
            miner.minerStateMachine.ChangeState(VisitBankAndDepositGold.Insatance);
        }
        else if (miner.IsThirsty())
        {
            miner.minerStateMachine.ChangeState(QuenchThirst.Instance);
        }
    }

    public override void Exit(Miner miner)
    {
        miner.WriteLog("Leaving the gold mine with the pockets full of sweet gold");
    }
}

public class VisitBankAndDepositGold : State<Miner>
{
    private VisitBankAndDepositGold()
    {

    }

    private static VisitBankAndDepositGold _instance = null;
    public static VisitBankAndDepositGold Insatance
    {
        get
        {
            if (_instance == null)
                _instance = new VisitBankAndDepositGold();

            return _instance;
        }
    }

    public override void Enter(Miner miner)
    {
        //on entry the miner makes sure he is located at the bank
        if (miner.CurLocation != WestWorldLocation.Bank)
        {
            miner.WriteLog("Goin' to the bank. Yes siree");
            miner.ChangeLocation(WestWorldLocation.Bank);
        }
    }

    public override void Execute(Miner miner)
    {
        //deposit the gold
        miner.PutMoneyToBank(miner.GoldCarried);

        miner.GoldCarried = 0;

        miner.WriteLog("Depositing gold. Total savings now: " + miner.MoneyInBank);

        //wealthy enough to have a well earned rest?
        if (miner.MoneyInBank >= Miner.COMFORT_LEVEL)
        {
            miner.WriteLog("WooHoo! Rich enough for now. Back home to mah li'lle lady");
            
            miner.minerStateMachine.ChangeState(GoHomeAndSleepTilRested.Instance);
        }

        //otherwise get more gold
        else
        {
            miner.minerStateMachine.ChangeState(EnterMineAndDigForNugget.Instance);
        }
    }


    public override void Exit(Miner miner)
    {
        miner.WriteLog("Leavin' the bank");
    }
}

public class GoHomeAndSleepTilRested : State<Miner>
{
    private GoHomeAndSleepTilRested()
    {

    }

    private static GoHomeAndSleepTilRested _instance;
    public static GoHomeAndSleepTilRested Instance
    {
        get
        {
            if (_instance == null)
                _instance = new GoHomeAndSleepTilRested();

            return _instance;
        }
    }

    public override void Enter(Miner miner)
    {
        if (miner.CurLocation != WestWorldLocation.Shack)
        {
            miner.WriteLog("Walkin' home");
            miner.ChangeLocation(WestWorldLocation.Shack);
        }
    }

    public override void Execute(Miner miner)
    {
        //if miner is not fatigued start to dig for nuggets again.
        if (miner.Fatigue > 0)
        {
            // sleep
            miner.DecreaseFatigue();
            miner.WriteLog("ZZZZ... ");
        }
        else
        {
            miner.WriteLog("What a God darn fantastic nap! Time to find more gold");
            miner.minerStateMachine.ChangeState(EnterMineAndDigForNugget.Instance);
        }
    }

    public override void Exit(Miner miner)
    {
        miner.WriteLog("Leaving the house");
    }
}

public class QuenchThirst : State<Miner>
{
    private QuenchThirst()
    {

    }

    private static QuenchThirst _instance;
    public static QuenchThirst Instance
    {
        get
        {
            if (_instance == null)
                _instance = new QuenchThirst();

            return _instance;
        }
    }

    public override void Enter(Miner miner)
    {
        if (miner.CurLocation != WestWorldLocation.Saloon)
        {
            miner.ChangeLocation(WestWorldLocation.Saloon);

            miner.WriteLog("Boy, ah sure is thusty! Walking to the saloon");
        }
    }

    public override void Execute(Miner miner)
    {
        if (miner.IsThirsty())
        {
            miner.BuyAndDrinkAWhiskey();

            miner.WriteLog("That's mighty fine sippin' liquer");

            miner.minerStateMachine.ChangeState(EnterMineAndDigForNugget.Instance);
        }
        else
        {
            throw new Exception("Not Thirsty?!");
        }
    }

    public override void Exit(Miner miner)
    {
        miner.WriteLog("Leaving the saloon, feelin' good");
    }
}

