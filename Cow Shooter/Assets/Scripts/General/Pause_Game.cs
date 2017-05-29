using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Game : MonoBehaviour {

	public GameObject pauseMenu;
	public Vector2 center;
	public GameObject canvas;
	private GameObject pauseMenuInstance;
	private KeyCode input;
	private KeyCode altInput;

	void Start() {
		GameObject temp = GameObject.FindWithTag ("Settings");
		if (temp == null) {
			print ("Settings not found, likely due to starting in the game arena instead of main menu. Defaulting to Keycode.P");
			input = KeyCode.P;
		} else {
			input = Settings.currentPreferences.pauseButton;
		}
		altInput = KeyCode.Escape;
	}

	void Update() {
		if (!GetComponent<InitialUI> ().gameTimer.timesUp) {
			if (Input.GetKeyDown (input) || Input.GetKeyDown (altInput)) {
				if (pauseMenuInstance == null) {
					pause ();
					showPauseMessage ();
				} else {
					unPause ();
					hidePauseMessage ();
				}
			}
		}
	}

    public void pause() {
        Time.timeScale = 0;
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
    }
}
