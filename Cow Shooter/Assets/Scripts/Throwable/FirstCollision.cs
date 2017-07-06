using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCollision : MonoBehaviour {

	public bool hasPassedThrough;
	public bool collidedAfterLaunch;

	void Start() {
		hasPassedThrough = false;
		collidedAfterLaunch = false;
	}

	public bool isFirstCollision() {
		return hasPassedThrough && !collidedAfterLaunch;
	}

	public virtual void onFirstCollision () {
		collidedAfterLaunch = true;
	}

	public void startLaunchedTimer() {
	}

	public void hasBeenLaunched() {
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (isFirstCollision()) {
			onFirstCollision ();
		}
	}
}
