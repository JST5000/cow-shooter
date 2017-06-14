using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public void playGame() {
		Settings.currentPreferences.enableAI = true;
		SceneShift.shiftScene ("Save_Select");
	}

	public void playGameLocal() {
		Settings.currentPreferences.enableAI = false;
		SceneShift.shiftScene ("Save_Select");
	}

	public void showSettings() {
		MenuHolder.showControlsMenu ();
	}

	public void exit() {
		Application.Quit ();
	}
}
