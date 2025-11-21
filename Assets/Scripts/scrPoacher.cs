using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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
    public GameObject Dart;
    public Transform dartPos;
    public AudioSource sound;
    public AudioClip huntingRilfeShot;
    #endregion

    #region Private Variables
    private GameObject player;
    private Animator animator;

    #endregion 

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < 10)
        {
            timer += Time.deltaTime;
            animator.SetBool("Attack", true);
            //animator.SetBool("isAttacking", false);

            if (timer > 2)
            {
                timer = 0;
                shoot();
            }
        }
        else
        {
            animator.SetBool("Attack", false);

        }
    }
    void shoot()
    {
        Instantiate(Dart, dartPos.position, Quaternion.identity);
        animator.SetBool("isAttacking", true);
        sound.PlayOneShot(huntingRilfeShot);
        Invoke("StopShoot", 2f);
    }
    void StopShoot()
    {
        sound.Stop();
    }
}