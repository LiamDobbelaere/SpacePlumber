using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    public AudioClip collectSound;

	// Use this for initialization
	void Start () {
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Manager manager = GameObject.Find("Canvas").GetComponent<Manager>();
            manager.Coins += 1;
            manager.AudioSource.PlayOneShot(collectSound);
            Destroy(gameObject);
        }
    }
}
