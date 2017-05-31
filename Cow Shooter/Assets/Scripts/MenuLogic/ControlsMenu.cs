using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsMenu : MonoBehaviour {

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			exitToScene ();
		}
	}

	public void exitButton() {
		if (SceneManager.GetActiveScene ().name == "Game Arena") {
			exitToSettings ();
		} else if (SceneManager.GetActiveScene ().name == "Main Menu") {
			exitInMainMenu ();
		}
	}

	private void exitInMainMenu() {
		apply ();
		MenuHolder.hideCurrentMenu ();
	}

	public void exitToScene() {
		apply ();
		GameObject permanent = GameObject.Find ("Global_Scripts");
		permanent.GetComponent<Pause_Game> ().unPause ();
		MenuHolder.hideCurrentMenu ();
	}

	public void exitToSettings() {
		apply ();
		MenuHolder.showPauseMenu ();
		//TODO change this to settings when settings is made
	}

	public void apply() {
		if (Settings.currentPreferences != null) {
			Settings.saveChanges ();
		}
	}
		
}
