using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayWalls : MonoBehaviour {

	private List<Collider2D> ignoreList;

	void Start() {
		ignoreList = new List<Collider2D> ();
	}
		
	void OnCollisionEnter2D(Collision2D col) {
		print ((col.gameObject.tag == "Throwable") + " " + (!col.gameObject.GetComponent<FirstCollision> ().hasPassedThrough));
		if (col.gameObject.tag == "Throwable" && !col.gameObject.GetComponent<FirstCollision> ().hasPassedThrough) {
			col.collider.isTrigger = true;
			col.collider.gameObject.GetComponent<FirstCollision> ().hasPassedThrough = true;
		}
	}

	void OnCollision2DExit(Collision2D col) {
		if (ignoreList.Contains (col.collider)) {
		//	reinstateCollisionWith (col.collider);
			col.collider.isTrigger = false;
			ignoreList.Remove (col.collider);
		}
	}
}
