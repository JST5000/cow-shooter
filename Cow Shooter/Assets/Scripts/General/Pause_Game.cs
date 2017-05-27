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

	void Start() {
		GameObject temp = GameObject.FindWithTag ("Settings");
		if (temp == null) {
			print ("Settings not found, likely due to starting in the game arena instead of main menu. Defaulting to Keycode.P");
			input = KeyCode.P;
		} else {
			input = temp.GetComponent<Settings> ().pauseButton;
		}
	}

	void Update() {
		if (GetComponent<InitialUI> ().isGamePlaying ()) {
			if (Input.GetKeyDown (KeyCode.P)) {
				pause ();
				showPauseMessage ();
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
