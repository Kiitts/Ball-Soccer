using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeeperMove : MonoBehaviour
{
    public float speed;
    public float kickStrength;

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
            other.rigidbody.AddForce(transform.forward * -1 * kickStrength, ForceMode.Impulse);
            Debug.Log("wt");
        }
    }
}
