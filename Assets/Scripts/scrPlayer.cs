using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    int speed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f);
        rb.AddForce(movement * speed);//multiplies by speed to see how fast the player moves
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 pos = transform.position;
            //Vector3 playerPos = new Vector3(transform.position, pos.y + 5, 0);
        }
    }
}
