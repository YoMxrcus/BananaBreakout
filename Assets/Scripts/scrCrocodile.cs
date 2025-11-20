using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class scrCrocodile : MonoBehaviour
{
    #region Public Variables
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance; //Minimum distance
    public float moveSpeed;
    public float timer; //Cooldown of attacks
    public GameObject dart;
    public GameObject pointA;
    public GameObject pointB;
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private Rigidbody2D rb;
    private GameObject target;
    private Animator animator;
    private float distance; //store distance between enemy and player
    private bool attackMode;
    private bool inRange; //See if player in range
    private bool cooling; //check if enemy is cooling after attack
    private float intTimer;
    private Transform currentPoint;
    #endregion 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentPoint = pointB.transform;
        animator.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position = transform.position;
        if (currentPoint == pointB.transform)
        {
            rb.linearVelocity = new Vector2(moveSpeed, 0);
        }
        else
        {
            rb.linearVelocity = new Vector2(-moveSpeed, 0);
        }

        if(Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }

}
