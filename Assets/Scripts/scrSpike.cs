using UnityEngine;

public class scrSpike : MonoBehaviour
{
    public GameObject droppedSpike;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody2D rb;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Player":
                Vector2 posSpike = new Vector2(transform.position.x, transform.position.y);
                GameObject instanceSpike = Instantiate(droppedSpike, posSpike, Quaternion.Euler(0, 0, 0));
                droppedSpike.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
                Destroy(gameObject);

                break;
        }
    }
}
