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
    void Awake()
    {
        Application.logMessageReceived += LogCallBack;
    }

    private void LogCallBack(string condition, string stackTrace, LogType type)
    {
        switch (type)
        {
            case LogType.Exception:
                Debug.Log("Exception Fired");
                break;
            case LogType.Error:
                break;
        }
    }

    Miner Bob;
    int loopCnt = 0;
    // Start is called before the first frame update
    void Start()
    {
        Bob = new Miner(1);
        Bob.minerStateMachine.ChangeState(EnterMineAndDigForNugget.Instance);
    }

    // Update is called once per frame
    void Update()
    {
        while(loopCnt <  20)
        {
            Debug.Log("Turn: " + loopCnt);
            Bob.Update();
            loopCnt++;
        }
    }

    void OnDestroy()
    {
        Application.logMessageReceived -= LogCallBack;
    }
}
