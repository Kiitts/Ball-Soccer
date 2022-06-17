using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedKeeper : Keeper
{
    protected override void SetColor()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }

    private void Start() 
    {
        SetColor();
    }
}
