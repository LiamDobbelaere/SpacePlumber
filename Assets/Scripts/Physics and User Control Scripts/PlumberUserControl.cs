using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlumberUserControl : MonoBehaviour {
    public GameObject Ground;
    public Animator SpriteControl;

    private Rigidbody2D rb;

    private bool grounded;

    void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Ground != null)
        {
            transform.right = Vector2.Lerp(transform.right, Vector2.Perpendicular(Ground.transform.position - transform.position), 2f * Time.fixedDeltaTime);
        }

        float hAxis = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(hAxis) > 0.1f)
        {
            Vector2 newSpeed = rb.velocity + (Vector2)transform.right * 100f * hAxis * Time.fixedDeltaTime;

            if (newSpeed.sqrMagnitude < 16)
            {
                rb.velocity = newSpeed;
            }
        }

        if (Input.GetButton("Jump") && grounded)
        {
            rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Planet")
        {
            Ground = collision.gameObject;
            grounded = true;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
    }
}
