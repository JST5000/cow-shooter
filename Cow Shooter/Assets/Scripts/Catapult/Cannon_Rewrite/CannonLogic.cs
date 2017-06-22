using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLogic : MonoBehaviour {

	public PowerControl velControl;
	public PowerControl rotControl;

	public Account deck;

	public MovePower indicator;

	public Vector3 spawnpoint;
	public bool isLeft;

	private Controls inputs;
	private int team;

	private GameObject throwableInstanceHolder;
	private GameObject loadedThrowable;
	private bool loaded;

	private int numberOfFired;

	void Awake () {
		instantiateVelControl ();
		instantiateRotControl ();
		getDeck ();
		initializeIndicator ();
		getControls();
		assignTeam ();
		getThrowableInstanceHolder ();
		loaded = true;
	}

	private void instantiateVelControl() {
		velControl = new PowerControl ();
		velControl.max = 12;
		velControl.min = 6;
		velControl.milliUntilMaxPower = 750;
		velControl.originalIncreasing = true;
		velControl.resetPower ();
	}

	private void instantiateRotControl() {
		rotControl = new PowerControl ();
		if (isLeft) {
			rotControl.max = 60;
			rotControl.min = 0;
			rotControl.originalIncreasing = true;
		} else {
			rotControl.max = 180;
			rotControl.min = 120;
			rotControl.originalIncreasing = false;
		}
		rotControl.milliUntilMaxPower = 1000;
		rotControl.originalIncreasing = isLeft;
		rotControl.resetPower ();
	}

	private void getDeck() {
		if (Settings.currentPreferences.enableAI) {
			if (LevelLoader.chosenLevel != null) {
				deck = LevelLoader.chosenLevel.enemy;
			} else {
				print ("Could not retrieve enemy deck");
			}
		} else {
			if (isLeft) {
				deck = SaveSlots.currentSaveSlots.blueTeamSave;
			} else {
				deck = SaveSlots.currentSaveSlots.redTeamSave;
			}
		}
	}

	private void initializeIndicator() {
		indicator = gameObject.AddComponent<MovePower> ();
		indicator.pow = velControl;
		indicator.isLeft = isLeft;
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

	void Update () {
		if (loaded) { 
			if (inputs.inputUp ()) {
				fire ();
				resetCannon ();
				numberOfFired++;
				print ("fired" + numberOfFired);
			}

			if (inputs.inputContinuous ()) {
				velControl.changePower ();
			} else {
				rotControl.changePower ();
				gameObject.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, rotControl.getCurrent ()));
			}
			inputs.informAI (velControl.getCurrentPercent (), rotControl.getCurrentPercent());
		} 

	}

	private void fire() {
		float theta = Mathf.Deg2Rad * rotControl.getCurrent ();
		Vector2 direction = new Vector2 (Mathf.Cos(theta), Mathf.Sin(theta));
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

	private void resetCannon() {
		velControl.resetPower ();
	}
		
}
