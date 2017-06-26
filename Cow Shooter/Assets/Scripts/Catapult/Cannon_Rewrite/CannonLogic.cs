using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonLogic : MonoBehaviour {

	private PowerControl velControl;
	private PowerControl rotControl;

	private Account deck;

	private MovePower indicator;

	private InitialUI gameStartIndicator;

	public Vector3 spawnpoint;
	public bool isLeft;

	private Controls inputs;
	private int team;

	private GameObject throwableInstanceHolder;
	private GameObject loadedThrowable;

	private AmmoHolder ammunition;

	void Awake () {
		instantiateVelControl ();
		instantiateRotControl ();
		getDeck ();
		initializeIndicator ();
		assignGameStartIndicator ();
		getControls();
		assignTeam ();
		getThrowableInstanceHolder ();
		getAmmunition ();
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

	private void assignGameStartIndicator() {
		gameStartIndicator = GameObject.Find ("Global_Scripts").GetComponent<InitialUI> ();
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

	private void getAmmunition() {
		ammunition = gameObject.AddComponent<AmmoHolder> ();
		if (isLeft) {
			ammunition.displacement = .8f;
			ammunition.farthestLeftLoc = new Vector2 (-9.4f, 4.3f);
		} else {
			ammunition.displacement = .8f;
			ammunition.farthestLeftLoc = new Vector2 (9.4f - 2 * ammunition.displacement, 4.3f);
		}
	}

	void Update () {
		if (gameStartIndicator.isGamePlaying () && Time.deltaTime != 0) {
			if (ammunition.hasAmmo ()) { 
				if (inputs.inputUp ()) {
					fire ();
					resetCannon ();
				}

				if (inputs.inputContinuous ()) {
					velControl.changePower ();
				} else {
					rotControl.changePower ();
					gameObject.transform.rotation = Quaternion.Euler (new Vector3 (0, 0, rotControl.getCurrent ()));
				}
				inputs.informAI (velControl.getCurrentPercent (), rotControl.getCurrentPercent ());
			} 
		}
	}

	private void fire() {
		ammunition.useAmmo ();

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
	}

	private void resetCannon() {
		velControl.resetPower ();
	}
		
}
