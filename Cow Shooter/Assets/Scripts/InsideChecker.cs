using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideChecker : MonoBehaviour {
    private PolygonCollider2D collider;
    private ArrayList comparePoints;
    public Team.suggestedTeams team;
    public int score;
    // Use this for initialization
    void Start () {
        score = 0;
        collider= GetComponent<PolygonCollider2D>();
        team= GetComponent<Team>().team;
        GameObject backgroundTarget= GameObject.Find("BackgroundTarget");
        PointCalculator pointCalculator = backgroundTarget.GetComponent<PointCalculator>();
        comparePoints = pointCalculator.finalPoints;
    }
	
	// Update is called once per frame
	void Update () {

        score = 0;
        foreach (Vector2 point in comparePoints) {
            if (collider.OverlapPoint(point))
            {
                score++;
            }
        }
        
    }
   
    
}
