using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Game : MonoBehaviour {

	public Vector2 center;
	public GameObject canvas;
	private bool paused;

	void Start() {
		paused = false;
		if (Settings.currentPreferences == null) {
			print ("Settings not found, likely due to starting in the game arena instead of main menu. Defaulting to Keycode.P");
		}
	}

	void Update() {
		if (!GetComponent<InitialUI> ().gameTimer.timesUp) {
			if (getInputDown ()) {
				if (!paused) {
					pause ();
					MenuHolder.showPauseMenu ();
				} else {
					unPause ();
					if (MenuHolder.currentDisplay != null && MenuHolder.currentDisplay.GetComponent<PauseMenu> () != null) {
						MenuHolder.hideCurrentMenu ();
					}
				}
			} 
		}
	}

	private bool getInputDown() {
		if (Settings.currentPreferences != null) {
			return Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown (Settings.currentPreferences.pauseButton);
		} else {
			return Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown (KeyCode.P);
		}
	}

    public void pause() {
        Time.timeScale = 0;
		paused = true;
    }

    public void unPause()
    {
        Time.timeScale = 1;
		paused = false;
    }
}
