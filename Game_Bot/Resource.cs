using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour 
{
    public bool IsTarget { get; private set; }

    private void Start()
    {
        IsTarget = false;
    }

    public void BecomeTarget()
    {
        IsTarget = true;
    }
}

