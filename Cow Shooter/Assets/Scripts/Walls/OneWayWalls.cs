using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayWalls : MonoBehaviour {

	private List<Collider2D> ignoreList;

	void Start() {
		ignoreList = new List<Collider2D> ();
	}
		
	void OnCollision2DEnter(Collision2D col) {
		if (col.gameObject.tag == "Throwable" && !col.gameObject.GetComponent<FirstCollision> ().collidedAfterLaunch) {
			col.collider.isTrigger = true;
		}
	}

	void OnCollision2DExit(Collision2D col) {
		if (ignoreList.Contains (col.collider)) {
			reinstateCollisionWith (col.collider);
			col.collider.isTrigger = false;
			ignoreList.Remove (col.collider);
		}
	}

	public void ignoreCollisionWith(Collider2D col) {
		Physics2D.IgnoreCollision (col, GetComponent<Collider2D> (), true);
		ignoreList.Add (col);
	}

	public void reinstateCollisionWith(Collider2D col) {
		Physics2D.IgnoreCollision (col, GetComponent<Collider2D> (), false);
	}
}
