using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlumberController : MonoBehaviour {
    private GameObject[] planets;
    private Rigidbody2D rigidbody2d;

	// Use this for initialization
	void Start () {
        planets = GameObject.FindGameObjectsWithTag("Planet");
        rigidbody2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        FixedGravityUpdate();
        FixedMovementUpdate();
    }

    void FixedMovementUpdate()
    {
        Vector2 forward = Vector2.Perpendicular(Physics2D.gravity.normalized);

        rigidbody2d.AddForce(forward * Input.GetAxisRaw("Horizontal") * 5f);

        if (Input.GetButtonDown("Jump"))
        {
            rigidbody2d.AddForce(-Physics2D.gravity.normalized * 2f, ForceMode2D.Impulse);
        }

        Debug.DrawRay(transform.position, forward * 1f, Color.green);
    }

    void FixedGravityUpdate()
    {
        Physics2D.gravity = CalculateGravityVector();
        Debug.DrawRay(transform.position, Physics2D.gravity * 1f, Color.cyan);
    }

    GameObject FindClosestPlanet()
    {
        GameObject closestPlanet = null;
        float closestDistance = Mathf.Infinity;
        Vector2 currentPosition = transform.position;

        foreach (GameObject planet in planets)
        {
            Vector2 vectorToTarget = (Vector2) planet.transform.position - currentPosition;
            float distanceSquared = vectorToTarget.sqrMagnitude;

            if (distanceSquared < closestDistance)
            {
                closestDistance = distanceSquared;
                closestPlanet = planet;
            }
        }

        return closestPlanet;
    }

    Vector2 CalculateGravityVector()
    {
        Vector2 gravityVector = new Vector2(0, 0);

        GameObject closest = FindClosestPlanet();

        if (closest != null)
        {
            Vector2 vectorToPlanet = closest.transform.position - transform.position;
            CircleCollider2D cc = closest.GetComponent<CircleCollider2D>();

            float estimatedRadius = cc.bounds.extents.x * 1.25f;
            float attractionPower = estimatedRadius / Vector2.Distance(closest.transform.position, transform.position);

            Debug.DrawLine(closest.transform.position, transform.position, Color.grey);

            gravityVector += vectorToPlanet.normalized * attractionPower * (closest.transform.localScale.magnitude * 0.2f);
        }

        return gravityVector;
    }

    //Realistic means all planets attract the object a certain amount all the time, like in space
    //Unfortunately, this isn't what we want for our platformer since it slings the player around
    //Left it here because it's cool
    Vector2 CalculateGravityVectorRealistic()
    {
        Vector2 gravityVector = new Vector2(0, 0);
        float planetCount = 0f;

        foreach (GameObject planet in planets)
        {
            Vector2 vectorToPlanet = planet.transform.position - transform.position;
            CircleCollider2D cc = planet.GetComponent<CircleCollider2D>();
            float estimatedRadius = cc.bounds.extents.x * 1.25f;

            Debug.DrawLine(planet.transform.position, (Vector2) planet.transform.position + Vector2.up * estimatedRadius, Color.magenta);

            float attractionPower = estimatedRadius / Vector2.Distance(planet.transform.position, transform.position);
            Debug.Log(attractionPower);

            Debug.DrawLine(transform.position, planet.transform.position, Color.gray);
            gravityVector += vectorToPlanet.normalized * attractionPower * (planet.transform.localScale.magnitude * 0.2f);
            planetCount += 1f;
        } 

        if (planetCount > 0)
        {
            gravityVector /= planetCount;
        }

        return gravityVector;
    }
}
