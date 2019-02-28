using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{

    public GameObject Player;
    public float moveFactor;
    private Rigidbody2D rb2d;
    private Rigidbody2D playerRb2D;
    private float difX;
    private float difY;
     
    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerRb2D = Player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
        rb2d.velocity = new Vector2(moveFactor * playerRb2D.velocity.x, moveFactor * playerRb2D.velocity.y);
        //Debug.Log("Player velocity: " + playerRb2D.velocity);
        //Debug.Log("BG velocity: " + rb2d.velocity);

        difX = Player.transform.position.x - transform.position.x;
        difY = Player.transform.position.y - transform.position.y;

        //Debug.Log(difX);

        if (difX >= 10) {
            transform.position = new Vector3(transform.position.x + 20, transform.position.y);
        }
        if (difX <= -10) {
            transform.position = new Vector3(transform.position.x - 20, transform.position.y);
        }
        if (difY >= 10) {
            transform.position = new Vector3(transform.position.x, transform.position.y + 20);
        }
        if (difY <= -10) {
            transform.position = new Vector3(transform.position.x, transform.position.y - 20);
        }
    }

    public void bgWarp(float transX, float transY)
    {
        transform.position = new Vector3(transform.position.x - transX, transform.position.y - transY, 0);
    }
}
