using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tether : MonoBehaviour {

	public bool isAttached;

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.tag == "Throwable") {
			createTether (col.gameObject);
		}
	}

	private void createTether(GameObject attached) {
		gameObject.AddComponent<FixedJoint2D> ().connectedBody = attached.GetComponent<Rigidbody2D> ();
		isAttached = true;
	}

	public void releaseTether() {
		if (isAttached) {
			Destroy (gameObject.GetComponent<FixedJoint2D> ());
			isAttached = false;
		} else {
			print ("Tried to disattach from something when was not attached");
		}
	}
}
