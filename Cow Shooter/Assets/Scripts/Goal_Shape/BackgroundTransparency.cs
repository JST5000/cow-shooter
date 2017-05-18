using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundTransparency : MonoBehaviour {
    public double transparancy;
	// Use this for initialization
	void Start () {
        SpriteRenderer spriteRenderer=GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1f, 1f, 1f, (float)transparancy);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
