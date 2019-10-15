using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldController : MonoBehaviour
{
    public int value = 1;
    private bool carry = false;
    private Vector3 playerPos;
    
    private void Update()
    {
        if (carry)
        {
            playerPos = GameObject.FindWithTag("Player").transform.position;

            transform.position = playerPos;
        }
    }
    
    public int getValue()
    {
        return value;
    }

    public void setCarry(bool val)
    {
        carry = val;
    }
}