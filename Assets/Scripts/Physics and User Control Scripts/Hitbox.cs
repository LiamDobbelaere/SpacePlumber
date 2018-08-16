using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Use this for initialization
        if (collision.gameObject.tag == "Feet")
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }

// Update is called once per frame
void Update () {
		
	}
}
