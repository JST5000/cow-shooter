using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideChecker : MonoBehaviour {
    private Collider2D coll;
    private ArrayList comparePoints;
    public int team;
    public int score;
    // Use this for initialization
    void Start () {
        score = 0;
        if (GetComponent<CircleCollider2D>() != null)
        {
            coll = GetComponent<CircleCollider2D>();
        }
        else
        {
            coll = GetComponent<PolygonCollider2D>();
        }
        team= GetComponent<Team>().team;
        GameObject allTargets= GameObject.Find("Targets");
        PointCalculator rightTarget = allTargets.GetComponent<PointCalculator>();
        comparePoints = rightTarget.finalPoints;
    }
	
	// Update is called once per frame
	void Update () {

        score = 0;
        foreach (Vector2 point in comparePoints) {
            if (coll.OverlapPoint(point))
            {
                score++;
            }
        }
        
    }
   
    
}
