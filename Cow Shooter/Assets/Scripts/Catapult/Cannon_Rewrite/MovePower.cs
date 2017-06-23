using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePower : MonoBehaviour {

	public PowerControl pow;
	public bool isLeft;

	protected GameObject movable;
    private float totalDistance;
	private float offset = .15f;
    private float position;
    private float percent;

	// Use this for initialization
	void Start () {
		updateMovable ();
		totalDistance = movable.GetComponentsInParent<SpriteRenderer>()[1].bounds.size.x - 2 * offset;
        position = -totalDistance / 2;
		movable.GetComponent<Transform> ().localPosition = new Vector3 (position, GetComponentInChildren<Transform> ().localPosition.y);
	}
	
	// Update is called once per frame
	void Update () {
		if (movable != null) {
			percent = pow.getCurrentPercent ();
			position = totalDistance * (percent / 100) - totalDistance / 2;
			movable.GetComponent<Transform> ().localPosition = new Vector3 (position, GetComponentInChildren<Transform> ().localPosition.y);
		}
		otherActions ();
	}

	protected virtual void updateMovable() {
		if (isLeft) {
			movable = GameObject.Find ("Left Powerbar/PowerIndicator");
		} else {
			movable = GameObject.Find ("Right Powerbar/PowerIndicator");
		}
	}

	protected virtual void otherActions() {
		//stub
	}
}
