using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
 
    [SerializeField] private float _speed;
    [SerializeField] private float _topSpeed;
    [SerializeField] private GroundSpawner _groundSpawner;
    [SerializeField] private Color _groundColor;
    [SerializeField] GameObject _gameOverPanel;
    private bool _is_It_Falling;
    private Vector3 _direction;
    InputController _input;  
    [SerializeField] PlayerScore playerScore;


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
        if(transform.position.y <= 0.671f)
            _is_It_Falling = true;

        if(_is_It_Falling == true)
        {
            StartCoroutine(GameOver(_gameOverPanel));
            return;
        }
            


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
        float x = playerScore._chracterScore;
        _topSpeed = _speed + x/250;
        Vector3 move = _direction * _topSpeed * Time.deltaTime;
        transform.position += move;
    }

   

    private void OnCollisionEnter(Collision collider) {
        if (collider.gameObject.tag == "Ground")
        {
            playerScore.scoreIncrease();
            collider.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        
    }

    private void OnCollisionExit(Collision collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            _groundSpawner.ground_spawner();
            collider.gameObject.GetComponent<Renderer>().material.color = _groundColor;
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

    IEnumerator GameOver(GameObject panel)
    {
        yield return new WaitForSeconds(0.4f);
        panel.SetActive(true);
    }
}
