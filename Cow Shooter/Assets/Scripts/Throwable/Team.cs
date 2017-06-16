using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Team : MonoBehaviour {

    public int team; 

	// Use this for initialization
	void Start () {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        
        if(team == 0) //blue
        {
            spriteRenderer.color = new Color(.15f, .15f, spriteRenderer.color.b + 8f);
        }
        if(team == 1) //red
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r + .8f, .15f, .15f);
        }
    }

}
