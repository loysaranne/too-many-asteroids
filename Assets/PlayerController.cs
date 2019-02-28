using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float aimOffset;
    public float maxX;
    public float maxY;
    public float speed;
    public float thrustForce;
    public float maxSpeed;
    public Rigidbody2D bullet;
    public float bulletSpeed;
    private float sqrMaxSpeed;
    private Rigidbody2D rb2d;
    private float oldX;
    private float oldY;
    private float dist;
    private GameObject[] backgrounds;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        sqrMaxSpeed = maxSpeed * maxSpeed;
        backgrounds = GameObject.FindGameObjectsWithTag("Background");
    }
	
	// Update is called once per frame
	void Update () {

    }

    void ShootBullet()
    {
        Rigidbody2D bulletClone = Instantiate(bullet, (transform.position + transform.right*0.5f), transform.rotation);
        //bulletClone.velocity = transform.forward * 100f * Time.deltaTime;
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        // Mouse aiming
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotation_z + aimOffset);

        // Acceleration and slowing down
        float vInput = Input.GetAxis("Vertical");
        if (vInput > 0)
        {
            Vector2 force = transform.right * thrustForce * vInput;
            rb2d.AddForce(force);

            if (rb2d.velocity.sqrMagnitude > maxSpeed)
            {
                rb2d.velocity = Vector2.ClampMagnitude(rb2d.velocity, maxSpeed);
            }
        }
        else if (vInput < 0)
        {
            Vector2 force = rb2d.velocity.normalized * (thrustForce / 2) * vInput;
            rb2d.AddForce(force);
        }

        // Shooting
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }

        // Keep ship in boundaries
        if (transform.position.x > maxX)
        {
            oldX = transform.position.x;
            transform.position = new Vector3(maxX * -1, transform.position.y, 0);
            dist = Vector3.Distance(new Vector3(oldX,0,0), new Vector3(transform.position.x, 0, 0));
            massBgWarp(dist, 0);
        }
        if (transform.position.x < maxX * -1)
        {
            oldX = transform.position.x;
            transform.position = new Vector3(maxX, transform.position.y, 0);
            dist = Vector3.Distance(new Vector3(oldX, 0, 0), new Vector3(transform.position.x, 0, 0));
            massBgWarp(-dist, 0);
        }

        if (transform.position.y > maxY)
        {
            oldY = transform.position.y;
            transform.position = new Vector3(transform.position.x, maxY * -1, 0);
            dist = Vector3.Distance(new Vector3(0, oldY, 0), new Vector3(0, transform.position.y, 0));
            massBgWarp(0, dist);
        }
        if (transform.position.y < maxY * -1)
        {
            oldY = transform.position.y;
            transform.position = new Vector3(transform.position.x, maxY, 0);
            dist = Vector3.Distance(new Vector3(0, oldY, 0), new Vector3(0, transform.position.y, 0));
            massBgWarp(0, -dist);
        }

    }

    void massBgWarp(float warpX, float warpY)
    {
        foreach (GameObject background in backgrounds)
        {
            BackgroundScript bgScript = background.GetComponent<BackgroundScript>();
            bgScript.bgWarp(warpX, warpY);
        }
    }
}
