using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlumberUserControl : MonoBehaviour {
    public GameObject Ground;
    public bool Jump;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

        if (Input.GetAxis("Horizontal") > 0.05 && Ground != null)
        {
            transform.RotateAround(Ground.transform.position, Vector3.forward, 40 * Time.deltaTime * -1);
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetAxis("Horizontal") < -0.05 && Ground != null)
        {
            transform.RotateAround(Ground.transform.position, Vector3.forward, 40 * Time.deltaTime * 1);
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetKeyDown("space") && Jump == false)
        {
            Jump = true;
            Debug.Log("ADD");
            GetComponent<Rigidbody2D>().AddForce(transform.TransformDirection(Vector3.up) * Time.deltaTime * 40000);
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Planet")
        {
            Ground = collision.gameObject;
            Jump = false;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Planet")
        {
          
        }
    }
}
