using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour {

	private Countdown gameTimer;
	public Pause_Game pauser;

	void Awake() {
		gameTimer = GameObject.Find ("GameTimer").GetComponent<Countdown> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && gameTimer.timesUp) {
			pauser.unPause ();
			SceneShift.shiftScene ("Game Arena");
		}
	}
}
