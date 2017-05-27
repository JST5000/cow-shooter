using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public GameObject globalScripts;

	void Awake() {
		globalScripts = GameObject.Find ("Global_Scripts");
	}

	public void resumeGame() {
		globalScripts.GetComponent<Pause_Game> ().hidePauseMessage ();
		globalScripts.GetComponent<Pause_Game> ().unPause ();
	}

	public void goToMainMenu() {
		globalScripts.GetComponent<Pause_Game> ().unPause ();
		globalScripts.GetComponent<SceneShift> ().shiftScene ("Main Menu");
	}

	public void showOptionMenu() {
		//TODO
	}

	public void exit() {
		Application.Quit ();
	}
}
