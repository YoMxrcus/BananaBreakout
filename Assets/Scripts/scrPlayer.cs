using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public int speed = 10;
    public float stamina = 250f;

    bool canSprint;
    bool canJump;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            { Sprint(); Debug.Log("sprint activated"); stamina--; }
            else
            { EndSprint(); }
        }
        if (stamina <= 0f)
        { EndSprint(); }
        if (Input.GetKey(KeyCode.LeftControl) && canJump)
        {
            //transform.localScale = new Vector2(1, 0.5f);
            transform.position = new Vector2(transform.position.x, transform.position.y - 0.01f);
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
        speed = 20;
    }
    void EndSprint()
    {
        speed = 10;
    }
}
