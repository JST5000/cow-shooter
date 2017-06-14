using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public GameObject globalScripts;

	void Awake() {
		globalScripts = GameObject.Find ("Global_Scripts");
	}

	public void resumeGame() {
		MenuHolder.hideCurrentMenu ();
		globalScripts.GetComponent<Pause_Game> ().unPause ();
	}

	public void goToMainMenu() {
		globalScripts.GetComponent<Pause_Game> ().unPause ();
		SceneShift.shiftScene ("Main Menu");
	}

	public void goToSettings() {
		MenuHolder.showControlsMenu ();
	}

	public void exit() {
		Application.Quit ();
	}
}
