using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsMenu : MonoBehaviour {

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			exitToGame ();
		}
	}

	public void exitToGame() {
		GameObject permanent = GameObject.Find ("Global_Scripts");
		permanent.GetComponent<Pause_Game> ().unPause ();
		destroySelf ();
	}

	public void exitToSettings() {
		GameObject permanent = GameObject.Find ("Global_Scripts");
		permanent.GetComponent<Pause_Game> ().showPauseMessage();
		destroySelf ();
	}

	public void destroySelf() {
		apply ();
		Destroy (gameObject);
	}

	public void apply() {
		if (Settings.currentPreferences != null) {
			Settings.saveChanges ();
		}
	}
		
}
