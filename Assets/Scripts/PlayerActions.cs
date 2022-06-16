using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public float kickStrength = 3;
    public ParticleSystem smokeParticle;
    public float boostStrength = 10;
    
    private GameManager _gameManager;
    private Rigidbody rb;
    private bool _onBoost;
    private GameObject _focalPoint;

    private void Start() 
    {
        // initialize gameManager script
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _focalPoint = GameObject.Find("Focal Point");
        rb = GetComponent<Rigidbody>();
    }
    private void OnCollisionEnter(Collision other) 
    {
        // Kick the ball
        if(other.gameObject.CompareTag("Ball"))
        {
            if(_gameManager.isGameActive)
            {
                Vector3 awayFromPlayer = other.transform.position - transform.position;
                other.rigidbody.AddForce(awayFromPlayer * kickStrength * rb.velocity.magnitude, ForceMode.Impulse);
                _gameManager.UpdateKickLeftText();
            }
        }
    }

    IEnumerator Boost()
    {
        if(!_onBoost)
        {
            _onBoost = true;
            smokeParticle.Play();
            float timeStamp = Time.time;
            rb.AddForce(_focalPoint.transform.forward * boostStrength, ForceMode.Impulse);
            while(Time.time < timeStamp + 2)
            {
                yield return null;
            }
            _onBoost = false;
        }
        else
        {
            yield return null;
        }
    }

    void OnBoost()
    {
        if(_gameManager.isGameActive)
        {
            StartCoroutine("Boost");
        }
    }
}
