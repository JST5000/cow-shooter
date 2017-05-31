using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Game : MonoBehaviour {

	public GameObject pauseMenu;
	public Vector2 center;
	public GameObject canvas;
	private GameObject pauseMenuInstance;
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
					showPauseMessage ();
				} else {
					unPause ();
					hidePauseMessage ();
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

	public void showPauseMessage() {
		if (pauseMenuInstance == null) {
			pauseMenuInstance = Instantiate (pauseMenu, center, new Quaternion ());
			pauseMenuInstance.transform.SetParent (canvas.transform, false);
			pauseMenuInstance.transform.localScale = new Vector3 (1, 1, 1);
		}
	}

	public void hidePauseMessage() {
		if (pauseMenuInstance != null) {
			Destroy (pauseMenuInstance.gameObject);
		}
	}

    public void unPause()
    {
        Time.timeScale = 1;
		paused = false;
    }
}
