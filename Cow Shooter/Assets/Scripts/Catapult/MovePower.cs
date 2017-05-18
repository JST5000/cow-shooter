using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePower : MonoBehaviour {

    public CatapultLogic catapult;
    public float offset;
    private float totalDistance;
    private float position;
    private float percent;

	// Use this for initialization
	void Start () {
        totalDistance = GetComponentsInParent<SpriteRenderer>()[1].bounds.size.x - 2 * offset;
        position = -totalDistance / 2;
	}
	
	// Update is called once per frame
	void Update () {
        percent = (catapult.power - catapult.minPower) / (catapult.maxPower - catapult.minPower);
        position = totalDistance * percent - totalDistance / 2;
        GetComponentInChildren<Transform>().localPosition = new Vector3(position, GetComponentInChildren<Transform>().localPosition.y);
	}
}
