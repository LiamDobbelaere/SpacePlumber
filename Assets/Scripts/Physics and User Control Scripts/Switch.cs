using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour {
    public UnityEvent SwitchTrigger;
    private StaticPlanetGravity pg;
    public Sprite Pressed;
    public SpriteRenderer SpriteBase;
    // Use this for initialization
    void Start() {
        pg = GetComponent<StaticPlanetGravity>();
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Vector2 approachVector = collision.transform.position - transform.position;
            Vector2 floor = Vector2.Perpendicular(pg.Gravity.normalized);
            float angle = Vector2.Angle(approachVector, floor);

            if (angle <= 135 && angle >= 45)
            {
                SwitchTrigger.Invoke();
                SpriteBase.sprite = Pressed;
                GetComponent<Collider2D>().enabled = false;
            }
            
        }
    }
}
