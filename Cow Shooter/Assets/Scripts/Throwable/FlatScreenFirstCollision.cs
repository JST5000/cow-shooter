using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatScreenFirstCollision : FirstCollision {

	public Sprite broken;

	public override void onFirstCollision () {
		collidedAfterLaunch = true;
		GetComponent<SpriteRenderer> ().sprite = broken;
		GetComponent<SpriteRenderer> ().sortingLayerName = "Throwables";
	}
}
