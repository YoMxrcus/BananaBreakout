using NUnit.Framework.Constraints;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class scrProjectile : MonoBehaviour
{
    //Object variables
    private GameObject player;
    private Rigidbody2D rb;
    public Transform target;
    public GameObject Dart;
    public float force;
    public float timer;


    //Movement variables
    //float speed = 0.2f;
    public int direction;
    //public Vector3 destination;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();        
        //defines player GameObject
        player = GameObject.Find("Player");
        //target = player.transform;
        Vector3 direction = player.transform.position - transform.position;
        rb.linearVelocity = new Vector2(direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot - 60);
    }

    
    void FixedUpdate()
    {
        //uses if statement to determine the direction
        /*if (direction == 0)
        {   //Moves the projectile towards the player using MoveTowards
            //transform.position = Vector2.MoveTowards(transform.position, target.position, speed);
            //Destroys the projectile instantiated after 2 seconds
            Destroy(dart, 2);
        }*/
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 4)
        {
            Destroy(Dart);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //checks the tag of an object with a collider to see if its a wall
        if (other.CompareTag("Wall"))
        {
            Destroy(Dart); //if so it destroys the projectile
        }
        if (other.CompareTag("Player"))
        {
            Destroy(Dart); //if so it destroys the projectile
            Debug.Log("PlayerHit");
        }
    }
}