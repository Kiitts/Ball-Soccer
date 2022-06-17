using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Keeper : MonoBehaviour
{
    private float speed = 10;
    private float kickStrength = 10;
    protected abstract void SetColor();


    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Barrier"))
        {
            speed *= -1;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // kick the ball
        if(other.gameObject.CompareTag("Ball"))
        {
            BallHandle(other);
        }
    }

    protected virtual void BallHandle(Collision other)
    {
        other.rigidbody.AddForce(transform.right * -1 * kickStrength, ForceMode.Impulse);
    }
}
