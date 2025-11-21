using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrPoacher: MonoBehaviour
{
    #region Public Variables
    public Transform rayCast;
    public LayerMask raycastMask;
    public float rayCastLength;
    public float attackDistance; //Minimum distance
    public float moveSpeed;
    public float timer; //Cooldown of attacks
    public GameObject dart;
    public Transform dartPos;
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private GameObject target;
    private GameObject player;
    //private Animator animator;
    private float distance; //store distance between enemy and player
    private bool attackMode;
    private bool inRange; //See if player in range
    private bool cooling; //check if enemy is cooling after attack
    private float intTimer;
    #endregion 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Awake()
    {
        intTimer = timer;
        //animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(transform.position, player.transform.position);
        Debug.Log(distance);

        if (distance < 10)
        {
            timer += Time.deltaTime;

            if (timer > 2)
            {
                timer = 0;
                shoot();
            }
        }

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
            //animator.SetBool("Run", false);
            StopAttack();
        }
    }
    void shoot()
    {
        Instantiate(dart, dartPos.position, Quaternion.identity);
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
            //animator.SetBool("Attack", false);
        }
    }

    void Move()
    {
        //animator.SetBool("Run", true); 

        Vector2 targetPosition = new Vector2(target.transform.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

    }

    void Attack()
    {
        timer = intTimer;
        attackMode = true;

        Vector2 pos = new Vector2(transform.position.x, transform.position.y);
        GameObject instance = Instantiate(dart, pos, Quaternion.Euler(0, 0, 0));

        if (timer % 10 == 0)
        { /*LaunchProjectile();*/ }
        //animator.SetBool("Run", false);
        //animator.SetBool("Attack", true);
    }
    void LaunchProjectile()
    {   //instantiates a projectile prefab
        GameObject instance = Instantiate(dart, transform.position, Quaternion.identity);
        instance.GetComponent<scrProjectile>().direction = 0;
        instance.GetComponent<scrProjectile>().target = GameObject.Find("Player").transform;
        //Uses GetComponent to get certain direction from the projectile script
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
        //animator.SetBool("Attack", false);
    }

    void RaycastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.red);
        }
        else if (attackDistance > distance)
        {
            Debug.DrawRay(rayCast.position, Vector2.left * rayCastLength, Color.green);
        }
    }

    public void TriggerCooling()
    {
        cooling = true;
    }
}