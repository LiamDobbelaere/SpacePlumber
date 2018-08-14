using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionStopper : MonoBehaviour {
    public PlumberUserControl Master;
    public bool left;
	// Use this for initialization
	void Update () {
		if (Master.gameObject.transform.localScale.x == -1)
        {
            left = false;
        }

        else
        {
            left = true;
        }
	}
	
	// Update is called once per frame
	public void OnTriggerEnter2D (Collider2D collision) {
        if (collision.gameObject.tag == "Obstacle")
        {
            if (left == true)
            {
                Master.CanMoveLeft = false;
            }
            else
            {
                Master.CanMoveRight = false;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Ground")
        {
            if (left == true)
            {
                Master.CanMoveLeft = true;
            }
            else
            {
                Master.CanMoveRight = true;
            }
        }
    }
}
