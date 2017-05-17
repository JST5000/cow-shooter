using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideChecker : MonoBehaviour {
    private BoxCollider2D collider;
    private ArrayList comparePoints;
    // Use this for initialization
    void Start () {
        collider= GetComponent<BoxCollider2D>();
        GameObject backgroundTarget= GameObject.Find("BackgroundTarget");
        PointCalculator pointCalculator = backgroundTarget.GetComponent<PointCalculator>();
        comparePoints = pointCalculator.finalPoints;
    }
	
	// Update is called once per frame
	void Update () {
        foreach (Vector2 point in comparePoints) {
            if (collider.OverlapPoint(point))
            {
                print("point is inside collider");
            }
        }
        
    }
    
}
