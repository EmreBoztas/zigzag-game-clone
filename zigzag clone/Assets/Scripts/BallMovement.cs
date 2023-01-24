using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
 
    [SerializeField] private float _speed;
    [SerializeField] private GroundSpawner groundSpawner;
    [SerializeField] private Color groundColor;
    InputController _input;    

    private Vector3 _direction;


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

   

    private void OnCollisionEnter(Collision collider) {
        if (collider.gameObject.tag == "Ground")
        {
            collider.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        
    }

    private void OnCollisionExit(Collision collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            groundSpawner.ground_spawner();
            collider.gameObject.GetComponent<Renderer>().material.color = groundColor;
            StartCoroutine(DeleteGround(collider.gameObject));
            StartCoroutine(FallOfTheGround(collider.gameObject));
        }
    }
    IEnumerator FallOfTheGround(GameObject ground)
    {
        yield return new WaitForSeconds(0.7f);
        ground.AddComponent<Rigidbody>();
        ground.GetComponent<Renderer>().material.color = Color.black;
    }

    IEnumerator DeleteGround(GameObject ground)
    {
        yield return new WaitForSeconds(3f);
        Destroy(ground);
    }

}
