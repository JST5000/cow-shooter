using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentFirstCollision : FirstCollision {

	public override void onFirstCollision () {
		collidedAfterLaunch = true;
		GetComponent<PresentBehavior> ().rerollCurrentObject ();
	}
}
