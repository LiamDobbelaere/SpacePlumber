using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoombaAI : MonoBehaviour {
    public GameObject Ground;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(Ground.transform.position, Vector3.forward, 40 * Time.deltaTime * -1);
    }
}
