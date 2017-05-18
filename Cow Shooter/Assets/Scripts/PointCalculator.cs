using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCalculator : MonoBehaviour {
    public int divisions;
    public int size;
    public ArrayList finalPoints;
	// Use this for initialization
	void Awake() {
        Transform transform = GetComponent<Transform>();
        Vector2 testPoint = new Vector2(transform.position.x, transform.position.y);
        PolygonCollider2D collider = GetComponent<PolygonCollider2D>();
        Bounds bounds = collider.bounds;
        float startX = bounds.center.x - bounds.extents.x;
        float endX = bounds.center.x + bounds.extents.x;
        float startY = bounds.center.y - bounds.extents.y;
        float endY = bounds.center.y + bounds.extents.y;
        float increment = ((bounds.size.x+bounds.size.y)/2) / divisions;
        float currentX = startX;
        float currentY = startY;
        finalPoints = new ArrayList();

        
        while (currentY <= endY)
        {
            while (currentX <= endX )
            {
                if (collider.OverlapPoint(new Vector2(currentX, currentY)))
                {
                    finalPoints.Add(new Vector2(currentX, currentY));
                }
                currentX += increment;
            }
            currentY += increment;
            currentX = startX;
        }
        collider.enabled = false;
        size = finalPoints.Count;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
