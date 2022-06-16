using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10;

    private float _movementX, _movementZ;
    private Rigidbody _rb;
    private GameObject _focalPoint;
    private Vector3 _direction;
    private GameManager _gameManager;


    // Start is called before the first frame update
    void Start()
    {
        // initialize rigid body
        _rb = GetComponent<Rigidbody>();
        // initialize focalpoint game object
        _focalPoint = GameObject.Find("Focal Point");
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(_gameManager.isGameActive)
        {
            Vector3 moveVectorZ = _focalPoint.transform.forward * _movementZ;
            Vector3 moveVectorX = _focalPoint.transform.right * _movementX;
            _rb.AddForce((moveVectorX + moveVectorZ).normalized * speed);
        }
    }

    void OnMove(InputValue inputValue)
    {
        Vector2 inputVector = inputValue.Get<Vector2>();
        _movementX = inputVector.x; _movementZ = inputVector.y;
    }
}
