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
    }

    void FixedGravityUpdate()
    {
        Physics2D.gravity = CalculateGravityVector();

        //rigidbody2d.AddForce(CalculateGravityVector());
    }

    /*GameObject FindClosestPlanet()
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
    }*/

    Vector2 CalculateGravityVector()
    {
        Vector2 gravityVector = new Vector2(0, 0);
        float planetCount = 0f;

        foreach (GameObject planet in planets)
        {
            Vector2 vectorToPlanet = planet.transform.position - transform.position;

            //sqrMagnitude can be seen as the pull distance
            //Should probably be multiplied with something rather than having this check
            if (vectorToPlanet.sqrMagnitude < 16)
            {
                gravityVector += vectorToPlanet.normalized * (planet.transform.localScale.magnitude * 0.2f);
                planetCount += 1f;
            }
        } 

        gravityVector /= planetCount;

        return gravityVector;
    }
}
