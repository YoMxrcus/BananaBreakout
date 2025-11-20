using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrEnemyScript : MonoBehaviour
{
    #region Public Variables
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance; //Minimum distance
    public float moveSpeed;
    public float timer; //Cooldown of attacks
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private GameObject target;
    public Animator anim;
    private float distance; //store distance between enemy and player
    private bool attackMode;
    private bool inRange; //See if player in range
    private bool cooling; //check if enemy is cooling after attack
    private float intTimer;
    #endregion 

    void Awake()
    {
        intTimer = timer;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            hit = Physics2D.Raycast(rayCast.position, Vector2.left, rayCastLength, raycastMask);
            RaycastDebugger();
        }

        //When player is detected
        if (hit.collider != null)
        {
            EnemyLogic();
        }
        else if (hit.collider == null)
        {
            inRange = false;
        }

        if (inRange == false)
        {
            anim.SetFloat("Speed", 0.0f);
            StopAttack();
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.tag == "Player")
        {
            target = trig.gameObject;
            inRange = true;
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);

        if (distance > attackDistance)
        {
            Move();
            StopAttack();
        }
        else if (attackDistance >= distance && cooling == false)
        {
            Attack();
        }

        if (cooling)
        {
            Cooldown();
            anim.SetBool("inRange", false);
        }
    }

    void Move()
    {
        anim.SetFloat("Speed", 0.1f); 

            Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    void Attack()
    {
        timer = intTimer;
        attackMode = true;

        anim.SetFloat("Speed", 0.1f);
        anim.SetBool("inRange", true);
    }

    void Cooldown()
    {
        timer -= Time.deltaTime;

        if (timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }

    void StopAttack()
    {
        cooling = false;
        attackMode = false;
        anim.SetBool("inRange", false);
    }

    void RaycastDebugger()
    {
        if (distance > attackDistance)
        {
            Flip();
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.red);
        }
        else if (attackDistance > distance)
        {
            Flip();
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.green);
        }
    }

    private void Flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    public void TriggerCooling()
    {
        cooling = true;
    }
}