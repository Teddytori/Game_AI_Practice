using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseGameEntity
{
    private enum EntityName
    {
        Unknown,
        Miner_Bob,
        Elsa
    }

    public int ID { get; private set; }
    private static int nextValidID = 0;
    private void SetID(int val)
    {
        if (val < nextValidID)
            throw new Exception("Invalid Entity ID");

        ID = val;
        nextValidID += 1;
    }

    public BaseGameEntity(int id)
    {
        SetID(id);
    }

    public static string GetNameOfEntity(int id)
    {
        return ((EntityName)id).ToString().Replace('_', ' ');
    }

    public void WriteLog(string message)
    {
        Debug.LogFormat("{0} : {1}", GetNameOfEntity(ID), message);
    }
}
