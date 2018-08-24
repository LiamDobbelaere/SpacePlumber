using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiteyPlant : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
       
            
            {
                collision.collider.GetComponent<PlumberController>().TakeDamage();
            }
        }
    }
