using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoombaAI : MonoBehaviour {
    public GameObject Ground;
    public int multiplier = 1;
    public bool change;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(Ground.transform.position, Vector3.forward, 15 * Time.deltaTime * multiplier);
        if (change == false)
        {
            StartCoroutine(SwitchDirection());
        }
    }

    public IEnumerator SwitchDirection()
    {
        change = true;
        yield return new WaitForSeconds(Random.Range(3, 10));
        multiplier *= -1;
        change = false;
    }

}
