using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBarDetection : MonoBehaviour
{
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Ball"))
        {
            if (_gameManager.isGameActive)
            {
                _gameManager.Win();
            }
            _gameManager.ballTouchGoal = true;
        }
    }
}
