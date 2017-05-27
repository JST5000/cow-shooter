using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	public void playGame() {
		GetComponent<SceneShift> ().shiftScene ("Game Arena");
	}

	public void exit() {
		Application.Quit ();
	}
}
