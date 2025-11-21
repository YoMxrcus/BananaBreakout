using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class scrCrocodile : MonoBehaviour
{
    #region Public Variables
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance; //Minimum distance
    public float moveSpeed;
    public float timer; //Cooldown of attacks
    public Transform startPos;
    public Transform endPos;
    bool endGoal = false;
    #endregion

    #region Private Variables
    private Rigidbody2D rb;
    private Animator animator;
    #endregion 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("isRunning", true);
        transform.position = startPos.transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == startPos.transform.position)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); endGoal = false;
        }
        else if (transform.position == endPos.transform.position)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0); endGoal = true;
        }
        if (!endGoal)
        {
            GoToEnd();
        }
        else
        {
            GoToStart();
        }
    }
    void GoToEnd()
    {
        transform.position = Vector2.MoveTowards(transform.position, endPos.transform.position, .01f);
    }
    void GoToStart()
    {
        transform.position = Vector2.MoveTowards(transform.position, startPos.transform.position, .01f);
    }
}
