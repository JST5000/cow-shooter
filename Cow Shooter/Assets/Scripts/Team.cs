using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : MonoBehaviour {

    public enum suggestedTeams : int {Blue, Red};
    public suggestedTeams team; 

	// Use this for initialization
	void Start () {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        
        if(team == suggestedTeams.Blue)
        {
            spriteRenderer.color = new Color(.15f, .15f, spriteRenderer.color.b + 8f);
        }
        if(team == suggestedTeams.Red)
        {
            spriteRenderer.color = new Color(spriteRenderer.color.r + .8f, .15f, .15f);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
