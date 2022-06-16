using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 9;

    private float _mouseX;
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_gameManager.isGameActive || _gameManager.timerStarted)
        {
            transform.Rotate(new Vector3(0, _mouseX, 0) * sensitivity * Time.deltaTime);
        }
    }

    void OnLook(InputValue inputValue)
    {
        _mouseX = inputValue.Get<Vector2>().x;
    }
}
