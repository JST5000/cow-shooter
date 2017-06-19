using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLogic : MonoBehaviour {

	public PowerControl velControl;
	public PowerControl rotControl;

	public Account deck;

	public Vector3 spawnpoint;
	public bool isLeft;

	private Controls inputs;
	private int team;

	private GameObject throwableInstanceHolder;
	private GameObject loadedThrowable;

	void Start () {
		instantiateVelControl ();
		instantiateRotControl ();
		assignTeam ();
		getControls();
		getThrowableInstanceHolder ();
	}

	private void instantiateVelControl() {
		velControl = new PowerControl ();
		velControl.max = 60;
		velControl.min = 20;
	}

	private void instantiateRotControl() {
		rotControl = new PowerControl ();
		rotControl.max = 80;
		rotControl.min = 20;
	}

	private void assignTeam() {
		if (isLeft) {
			team = 0;
		} else {
			team = 1;
		}
	}

	private void getControls() {
		if (Settings.currentPreferences.enableAI) {
			inputs = new AIControls ();
		} else {
			inputs = new PlayerControls ();
		}
		if (inputs is PlayerControls) {
			PlayerControls reference = (PlayerControls)inputs;
			reference.isLeft = isLeft;
		}
	}

	private void getThrowableInstanceHolder() {
		throwableInstanceHolder = GameObject.Find ("ThrowableInstanceHolder");
	}

	void FixedUpdate () {
		if (loadedThrowable != null) { 
			if (inputs.inputUp ()) {
				fire ();
			}

			if (inputs.inputContinuous ()) {
				velControl.changePower ();
			} else {
				rotControl.changePower ();
			}
			inputs.informControls (velControl.getCurrentPercent (), rotControl.getCurrentPercent());
		}

	}

	private void fire() {
		float theta = rotControl.getCurrent ();
		Vector2 direction = new Vector2 (Mathf.Cos(theta), Mathf.Sin(theta)); //TODO
		Vector2 vel = direction * velControl.getCurrent ();
		Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, theta));
		loadedThrowable = Account.spawnRandom (spawnpoint, true, deck);
		loadedThrowable.transform.localRotation = rotation;
		loadedThrowable.transform.SetParent (throwableInstanceHolder.transform);
		loadedThrowable.GetComponent<Rigidbody2D> ().velocity = vel;

		loadedThrowable.GetComponent<Team> ().team = team;
		loadedThrowable.GetComponent<FirstCollision> ().hasBeenLaunched ();
		//Let it through the one way wall
	}
		
}
