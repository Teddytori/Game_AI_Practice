using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WestWorldLocation
{
    None,
    Shack,
    Goldmine,
    Bank,
    Saloon,
}

public class MainLoop : MonoBehaviour
{
    Miner Bob;
    int loopCnt = 1;
    // Start is called before the first frame update
    void Start()
    {
        Bob = new Miner(1);
        Bob.ChangeState(EnterMineAndDigForNugget.Instance);
    }

    // Update is called once per frame
    void Update()
    {
        while(loopCnt <=  5)
        {
            Debug.Log("Turn: " + loopCnt);
            Bob.Update();
            loopCnt++;
        }
    }
}
