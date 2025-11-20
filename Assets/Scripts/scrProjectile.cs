using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class scrProjectile : MonoBehaviour
{
    //Object variables
    public GameObject player;
    public Transform target;
    public GameObject dart;


    //Movement variables
    float speed = 0.2f;
    public int direction;
    public Vector3 destination;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //defines player GameObject
        player = GameObject.Find("Player");
        target = player.transform;
    }

    void FixedUpdate()
    {
        //uses if statement to determine the direction
        if (direction == 0)
        {   //Moves the projectile towards the player using MoveTowards
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed);
            //Destroys the projectile instantiated after 2 seconds
            //Destroy(dart, 2);
        }
    }

    /*public void OnTriggerEnter(Collider other)
    {
        //checks the tag of an object with a collider to see if its a wall
        if (other.CompareTag("Wall"))
        {
            Destroy(projectile); //if so it destroys the projectile
        }
        if (other.CompareTag("Player"))
        {
            Destroy(projectile); //if so it destroys the projectile
        }
    }*/
}