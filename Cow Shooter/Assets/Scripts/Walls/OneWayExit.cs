using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayExit : MonoBehaviour {

	public GameObject wall;

	void OnCollisionExit2D(Collision2D col) {
		reinstateCollisionWith (col.collider);
	}

	public void ignoreCollisionWith(Collider2D col) {
		Physics2D.IgnoreCollision (col, GetComponent<Collider2D> (), true);
	}

	public void reinstateCollisionWith(Collider2D col) {
		Physics2D.IgnoreCollision (col, GetComponent<Collider2D> (), false);
	}


}
