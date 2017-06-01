using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public void playGame() {
		Settings.currentPreferences.enableAI = true;
		GetComponent<SceneShift> ().shiftScene ("Game Arena");
	}

	public void playGameLocal() {
		Settings.currentPreferences.enableAI = false;
		GetComponent<SceneShift> ().shiftScene ("Game Arena");
	}

	public void showSettings() {
		MenuHolder.showControlsMenu ();
	}

	public void exit() {
		Application.Quit ();
	}
}
