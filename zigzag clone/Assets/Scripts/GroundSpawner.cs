using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject last_ground;
    Vector3 direction;
    private int first = 0;
    private int second = 0;

    void Start()
    {
        for(int i = 0; i < 23 ;i++)
        {
            ground_spawner();
        }
    }

    public void ground_spawner()
    {
        
        
        if(((Random.Range(0,2) == 0) && first < 2) || second > 2)
        {
            direction = Vector3.left;
            first++;
            second = 0;
        }
        else
        {
            direction = Vector3.forward;
            second++;
            first = 0;
        }


        last_ground = Instantiate(last_ground, last_ground.transform.position+direction,last_ground.transform.rotation); 
    }
}
