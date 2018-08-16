using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportRing : MonoBehaviour {
    public bool InRange;
    public bool Teleporting;
    public Transform SuperPlumber;
    public Transform Teleport;
    // Use this for initialization
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InRange = true;
            SuperPlumber = collision.transform.parent.transform;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InRange = false;
        }
    }
    // Update is called once per frame
    void FixedUpdate () {
		if (Input.GetKeyDown("space") && InRange == true)
        {
            Teleporting = true;
        }

        if (Teleporting == true)
        {
            SuperPlumber.position = Vector2.MoveTowards(new Vector2(SuperPlumber.position.x, SuperPlumber.position.y), Teleport.position, 200 * Time.deltaTime);
            SuperPlumber.GetComponent<Rigidbody2D>().isKinematic = true;
            SuperPlumber.GetComponent<PlumberUserControl>().CanMoveLeft = false;
            SuperPlumber.GetComponent<PlumberUserControl>().CanMoveRight = false;
            SuperPlumber.GetComponent<PlumberUserControl>().Jump = true;
        }

        if (SuperPlumber.position == Teleport.position)
        {
            Teleporting = false;
            SuperPlumber.transform.rotation = Teleport.transform.rotation;
            SuperPlumber.GetComponent<Rigidbody2D>().isKinematic = false;
            SuperPlumber.GetComponent<PlumberUserControl>().CanMoveLeft = true;
            SuperPlumber.GetComponent<PlumberUserControl>().CanMoveRight = true;
            SuperPlumber.GetComponent<PlumberUserControl>().Jump = false;
        }
	}
}
