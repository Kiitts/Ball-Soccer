using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueKeeper : Keeper
{
    protected override void SetColor()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }

    private void Start() 
    {
        SetColor();
    }

    protected override void BallHandle(Collision other)
    {
        other.rigidbody.velocity = Vector3.zero;
        other.rigidbody.angularVelocity = Vector3.zero;
        Destroy(transform.parent.gameObject);
    }
}
