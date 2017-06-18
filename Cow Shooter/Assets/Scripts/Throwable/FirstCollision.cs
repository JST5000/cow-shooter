using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCollision : MonoBehaviour {

	private bool launched;
	public bool collidedAfterLaunch;
	private float timeDelay;
	private bool countdown;

	void Start() {
		launched = false;
		collidedAfterLaunch = false;
		timeDelay = .1f;
		countdown = false;
	}

	void Update() {
		if (countdown) {	
			timeDelay -= Time.deltaTime;
			if (timeDelay <= 0) {
				launched = true;
				countdown = false;
			}
		}
	}

	public bool isFirstCollision() {
		return launched && !collidedAfterLaunch;
	}

	public virtual void onFirstCollision () {
		collidedAfterLaunch = true;
	}

	public void startLaunchedTimer() {
		countdown = true;
	}

	public void hasBeenLaunched() {
		launched = true;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (isFirstCollision()) {
			onFirstCollision ();
		}
	}
}
