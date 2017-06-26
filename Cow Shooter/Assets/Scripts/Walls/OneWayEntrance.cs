using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayEntrance : MonoBehaviour {

	public GameObject wall;
	public bool isExit;

	void OnTriggerEnter2D(Collider2D col) {
		if (!isExit) {
			wall.GetComponent<OneWayExit> ().ignoreCollisionWith (col);
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (isExit) {
			wall.GetComponent<OneWayExit> ().reinstateCollisionWith (col);
		}
	}
}
