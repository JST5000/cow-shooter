using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayEntrance : MonoBehaviour {

	public GameObject exit;

	void OnTriggerEnter2D(Collider2D col) {
		exit.GetComponent<OneWayExit> ().ignoreCollisionWith (col);
	}
}
