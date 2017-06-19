using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLogic : MonoBehaviour {

	public PowerControl pow;

	public Account deck;

	public Controls inputs;

	public Vector3 spawnpoint;
	public Quaternion rot;
	public bool isLeft;

	private GameObject throwableInstanceHolder;
	private GameObject loadedThrowable;

	// Use this for initialization
	void Start () {

	}
	

	void FixedUpdate () {
		if (loadedThrowable != null) { 
			if (inputs.inputContinuous ()) {
				pow.changePower();
			} else if (inputs.inputUp ()) {
				Vector2 direction = new Vector2 (); //TODO
				Vector2 vel = direction * pow.getCurrentSpeed ();
				//Fire -
				//spawn throwable
				//Give it necessary attributes such as team
				//Give it vel
				//Let it through the one way wall if necessary
				loadedThrowable = null;
			} else {
				//Rotate
			}
		}

	}
		
}
