using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseGameEntity
{
    private int m_ID;
    private static int m_iNextValidID = 0;
    private void SetID(int val)
    {
        if (val < m_iNextValidID)
            throw new Exception("Invalid Entity ID");

        m_ID = val;
        m_iNextValidID += 1;
    }

    public BaseGameEntity(int id)
    {
        SetID(id);
    }
}
