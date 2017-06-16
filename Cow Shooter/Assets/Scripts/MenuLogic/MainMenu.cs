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

	public void openInstructions() {
		GameObject instance = Instantiate ((GameObject)Resources.Load (Application.persistentDataPath +
			"UI_Prefabs/" + "Instructions"), GameObject.Find ("Canvas").transform);
		instance.transform.localPosition = new Vector2 ();
	}

	public void exit() {
		Application.Quit ();
	}
}
