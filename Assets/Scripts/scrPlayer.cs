using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed = 10;
    public float stamina = 100f;
    private CapsuleCollider2D capsuleCollider;
    private Vector2 capsuleColliderSize = new Vector2(0.5f, 1);
    bool canJump;

    public Slider staminaBar;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0.0f);
        rb.AddForce(movement * speed);//multiplies by speed to see how fast the player moves
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce((new Vector2(0.0f, 300.0f)) * 1.5f);
            Debug.Log("Jump");
        }
        if (stamina > 0f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            { Sprint(); stamina--; staminaBar.value = stamina; }
            else
            { EndSprint(); staminaBar.value = stamina; }
        }
        if (stamina <= 0f)
        { EndSprint(); }
        if (Input.GetKeyDown(KeyCode.LeftControl) && canJump)
        {
            capsuleCollider.size = capsuleColliderSize;
            transform.localScale = new Vector2(1, 0.5f); 
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.01f);
            rb.AddForce((new Vector2(250.0f, 0.0f)) * 1.5f);
            Invoke("StopSlide", 0.5f);

        }
        

    }
    void OnCollisionStay2D(Collision2D collision)
    {
        canJump = true;
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        canJump = false;
    }
    void Sprint()
    {
        speed = 15;
    }
    void EndSprint()
    {
        speed = 10;
        if (stamina < 100)
        { stamina+= 0.25f; }
    }
    void StopSlide()
    {
        transform.localScale = new Vector2(1, 1);
        speed = 10;
    }
    void Launch()
    {
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.AddForce((new Vector2(1000.0f, 300.0f)) * 1.5f);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "slingshot":
                rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                Invoke("Launch", 1);
                break;
        }
    }
}
