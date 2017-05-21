using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour {
    float explosion_delay;
    public float explosion_rate = 1f;
    public float explosion_max_size = 10f;
    public float explosion_speed = 1f;
    public float max_delay;
    public float power;
	public bool dampen;
    bool exploded = false;
    float current_radius=0f;
    public CircleCollider2D explosion_radius;
	// Use this for initialization
	void Start () {
        if (GetComponent<Transform>().parent.tag != "ThrowableHolder")
        {
            explosion_delay = max_delay;
            // explosion_radius = gameObject.GetComponent<CircleCollider2D>();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Transform>().parent.tag != "ThrowableHolder")
        {
            explosion_delay -= Time.deltaTime;
            if (explosion_delay < 0)
            {
                exploded = true;
            }
        }
	}
    private void FixedUpdate()
    {
        if (GetComponent<Transform>().parent.tag != "ThrowableHolder")
        {
            if (exploded)
            {
                if (current_radius < explosion_max_size)
                {
                    current_radius += explosion_rate;
                }
                else
                {
                    Object.Destroy(this.gameObject);
                }
				if (explosion_radius != null) {
					explosion_radius.radius = current_radius;
				}




            }
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (GetComponent<Transform>().parent.tag != "ThrowableHolder") //Not a prefab
        {
            if (exploded)
            {
                if (col.gameObject.GetComponent<Rigidbody2D>() != null)
                {
					
                    Vector2 target = col.gameObject.transform.position;
                    Vector2 bomb = gameObject.transform.position;
                    Vector2 direction = power* (target - bomb);
					if (dampen) {
						float dampeningRatio = 1 - current_radius / explosion_max_size;
						direction *= dampeningRatio;
					}
                    col.gameObject.GetComponent<Rigidbody2D>().AddForce(direction);

                }



            }
        }
    }
}
