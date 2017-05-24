using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCollision : MonoBehaviour {

	public bool launched;
	public bool collidedAfterLaunch;

	void Start() {
		launched = false;
		collidedAfterLaunch = false;
	}

	public bool isFirstCollision() {
		return launched && !collidedAfterLaunch;
	}

	public void onFirstCollision () {
		collidedAfterLaunch = true;
	}

	void OnCollisionEnter(Collision collision)
	{
		if (isFirstCollision()) {
			onFirstCollision ();
		}
	}
}
