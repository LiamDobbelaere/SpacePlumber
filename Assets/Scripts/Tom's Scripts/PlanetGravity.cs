using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class PlanetGravity : MonoBehaviour {
    private GameObject[] planets;
    private Rigidbody2D rigidbody2d;
    private Transform sprite;

    public Vector2 Gravity { get; private set; }

    // Use this for initialization
    void Start () {
        planets = GameObject.FindGameObjectsWithTag("Planet");
        rigidbody2d = GetComponent<Rigidbody2D>();
        sprite = transform.Find("SpriteContainer");
        Gravity = new Vector2(0, 0);
    }

    // Update is called once per frame
    void FixedUpdate() {
        Gravity = CalculateGravityVector();
        FixedGravityUpdate();
	}

    void Update()
    {
        UpdateSpriteRotation();
    }

    void FixedGravityUpdate()
    {
        rigidbody2d.AddForce(Gravity);
    }

    void UpdateSpriteRotation()
    {
        Vector3 newAngles = new Vector3(0, 0, Vector2.SignedAngle(Vector2.down, Gravity.normalized));

        sprite.rotation = Quaternion.Lerp(Quaternion.Euler(sprite.localEulerAngles), Quaternion.Euler(newAngles), 10f * Time.fixedDeltaTime);
    }

    GameObject FindClosestPlanet()
    {
        GameObject closestPlanet = null;
        float closestDistance = Mathf.Infinity;
        Vector2 currentPosition = transform.position;

        foreach (GameObject planet in planets)
        {
            Vector2 vectorToTarget = (Vector2)planet.transform.position - currentPosition;
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

            gravityVector += vectorToPlanet.normalized * attractionPower * (closest.transform.localScale.magnitude);
        }

        return gravityVector;
    }
}
