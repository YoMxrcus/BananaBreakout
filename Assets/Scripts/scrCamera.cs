using UnityEngine;

public class scrCamera : MonoBehaviour
{
    Vector3 offset;
    GameObject player;
    public float lerpSpeed;

    void Start()
    {
        player = GameObject.Find("Player");
        offset = transform.position - player.transform.position;
    }


    void FixedUpdate()
    {
        //plain movement
        transform.position = new Vector3 (player.transform.position.x, 0, -10);
    }
}
