using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour {
    public Animator PlumberSprite;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D hit) {
		if (hit.gameObject.tag == "Player")
        {
            PlumberSprite.SetTrigger("End");
            GameObject.Find("Plum").transform.SetParent(GameObject.Find("Plumber").transform.Find("SpriteContainer").transform.Find("Sprite").transform);
            GameObject.Find("Plumber").GetComponent<PlumberController>().dead = true;
            GameObject.Find("End").GetComponent<Text>().enabled = true;
            LoadSceneDelayed x = gameObject.AddComponent<LoadSceneDelayed>();
            x.delayInSeconds = 4;
            x.sceneName = "Winner";
        }
    }
}
