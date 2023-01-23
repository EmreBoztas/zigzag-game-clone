using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Vector3 _direction;
    [SerializeField] private float _speed;
    [SerializeField] private GroundSpawner groundSpawner;
    InputController _input;    
    private void Awake()
    {
        _input = new InputController();
    }
    void Start()
    {
        _direction = Vector3.forward;
    }

    void Update()
    {
        if (_input.SpacePressed)
        {
            if(_direction.x == 0)
            {
                _direction = Vector3.left;
            }
            else
            {
                _direction = Vector3.forward;
            }
        }
    }
    private void FixedUpdate()
    {
        Vector3 move = _direction * _speed * Time.deltaTime;
        transform.position += move;
    }
    
    private void OnCollisionExit(Collision collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            groundSpawner.ground_spawner();
        }
    }
}
