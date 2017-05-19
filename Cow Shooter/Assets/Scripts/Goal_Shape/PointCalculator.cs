using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCalculator : MonoBehaviour {
    public float transparancy;
    public int divisions;
    public int size;
    public bool active;
    public ArrayList finalPoints;
	// Use this for initialization
	void Awake() {
        List<GameObject> listTargets = GetAllChildren(gameObject);
        int random = ((int)Random.Range(0, listTargets.Count));
        print("random is "+random);
        GameObject bestTarget = listTargets[random];
        listTargets.Remove(bestTarget);
        Transform transform = bestTarget.GetComponent<Transform>();
        PolygonCollider2D collider = bestTarget.GetComponent<PolygonCollider2D>();
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
        foreach(GameObject thing in listTargets)
        {
            thing.GetComponent<PolygonCollider2D>().enabled = false;
            thing.GetComponent<SpriteRenderer>().enabled = false;
        }
        collider.enabled = false;
        bestTarget.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, (float)transparancy);
        size = finalPoints.Count;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    List<GameObject> GetAllChildren(GameObject obj)
    {
        List<GameObject> children = new List<GameObject>();

        foreach (Transform child in obj.transform)
        {
            children.Add(child.gameObject);
            children.AddRange(GetAllChildren(child.gameObject));
        }

        return children;
    }
}
