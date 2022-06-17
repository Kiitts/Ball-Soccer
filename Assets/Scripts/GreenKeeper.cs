using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenKeeper : Keeper
{
    protected override void SetColor()
    {
        GetComponent<Renderer>().material.color = Color.green;
    }

    private void Start() 
    {
        SetColor();
    }
}
