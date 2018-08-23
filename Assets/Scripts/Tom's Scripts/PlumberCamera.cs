using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlumberCamera : MonoBehaviour {
    public float lerpSpeed = 10f;

    public Transform plumber;

    private PlanetGravity pg;

    // Use this for initialization
    void Start () {
        pg = plumber.GetComponent<PlanetGravity>();
    }

    // Update is called once per frame
    void FixedUpdate () {
        Vector2 currentPos = transform.position;
        currentPos = Vector2.Lerp(currentPos, plumber.position, lerpSpeed * Time.fixedDeltaTime);

        Vector3 newAngles = new Vector3(0, 0, Vector2.SignedAngle(Vector2.down, pg.Gravity.normalized));

        transform.position = currentPos;
        transform.rotation = Quaternion.Lerp(Quaternion.Euler(transform.localEulerAngles), Quaternion.Euler(newAngles), lerpSpeed * Time.fixedDeltaTime);
    }
}
