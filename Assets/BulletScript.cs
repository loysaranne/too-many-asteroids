using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    public float bulletSpeed;
    private GameObject Player;
    private Rigidbody2D rb2d;
    private Vector2 bulletVelocity;

    // Use this for initialization
    void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        rb2d = GetComponent<Rigidbody2D>();
        bulletVelocity = transform.right * bulletSpeed * 100 * Time.deltaTime;
        rb2d.velocity = bulletVelocity + Player.GetComponent<Rigidbody2D>().velocity;
        StartCoroutine(DestroyBullet());
    }

    IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(50*Time.deltaTime);
        Destroy(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
