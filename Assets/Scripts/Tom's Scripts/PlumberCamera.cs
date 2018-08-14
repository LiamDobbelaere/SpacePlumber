using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlumberCamera : MonoBehaviour {
    public float lerpSpeed = 10f;

    private Transform plumber;

    // Use this for initialization
    void Start () {
        plumber = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate () {
        Vector2 currentPos = transform.position;

        currentPos = Vector2.Lerp(currentPos, plumber.position, lerpSpeed * Time.fixedDeltaTime);

        transform.position = currentPos;
    }
}
