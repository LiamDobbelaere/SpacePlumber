using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlanetGravity))]
public class BoombaAI : MonoBehaviour {
    private PlanetGravity pg;
    private Rigidbody2D rigidbody2d;

    private float direction = 1f;
    private Vector2 lastPosition;

	// Use this for initialization
	void Start () {
        pg = GetComponent<PlanetGravity>();
        rigidbody2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void FixedUpdate()
    {
        FixedMovementUpdate();
    }

    void FixedMovementUpdate()
    {
        Vector2 forward = Vector2.Perpendicular(pg.Gravity.normalized);
        rigidbody2d.AddForce(forward * direction * 20f);
        rigidbody2d.velocity = Vector2.ClampMagnitude(rigidbody2d.velocity, 1f);

        if (lastPosition != null)
        {
            Vector2 currentPosition = transform.position;

            if ((currentPosition - lastPosition).sqrMagnitude == 0) direction *= -1f;
        }

        lastPosition = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Vector2 approachVector = collision.transform.position - transform.position;
            Vector2 floor = Vector2.Perpendicular(pg.Gravity.normalized);
            float angle = Vector2.Angle(approachVector, floor);

            if (angle <= 135 && angle >= 45)
            {
                Destroy(gameObject);
            }
            else
            {
                collision.collider.GetComponent<PlumberController>().TakeDamage();
            }
        }
    }
}
