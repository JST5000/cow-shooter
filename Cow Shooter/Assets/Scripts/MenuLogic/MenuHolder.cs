using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHolder : MonoBehaviour {

	public static GameObject currentDisplay;

	public static GameObject pauseMenu;
	public static GameObject controlsMenu;

	private static Vector2 center;

	private static string filename = "UI_Prefabs/";
	//public static GameObject settingsMenu;

	// Use this for initialization
	void Awake() {
		pauseMenu = (GameObject)Resources.Load (filename + "Pause_Menu");
		controlsMenu = (GameObject)Resources.Load (filename + "Controls_Menu");
		center = new Vector2 (0, 0);
	}
		
	public static void showPauseMenu() {
		hideCurrentMenu ();
		currentDisplay = Instantiate (pauseMenu, center, new Quaternion ());
		currentDisplay.transform.SetParent (GameObject.Find("Canvas").transform, false);
		currentDisplay.transform.localScale = new Vector3 (1, 1, 1);
	}

	public static void hideCurrentMenu() {
		if (currentDisplay != null) {
			Destroy (currentDisplay.gameObject);
		}
	}

	public static void showControlsMenu() {
		hideCurrentMenu ();
		currentDisplay = Instantiate (controlsMenu, center, new Quaternion ());
		currentDisplay.transform.SetParent (GameObject.Find("Canvas").transform, false);
		currentDisplay.transform.localScale = new Vector3 (1, 1, 1);
	}
}
