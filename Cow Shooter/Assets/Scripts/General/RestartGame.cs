using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour {

	private Countdown gameTimer;
	public Pause_Game pauser;
	private float gracePeriod = .5f;
	private float goalTime;

	void Awake() {
		gameTimer = GameObject.Find ("GameTimer").GetComponent<Countdown> ();
		goalTime = -1;
	}
	
	// Update is called once per frame
	void Update () {
		if (gameTimer.timesUp) {
			if (goalTime < 0) {
				goalTime = Time.realtimeSinceStartup + gracePeriod;
			}
		}
		if (gameTimer.timesUp && Input.anyKeyDown && Time.realtimeSinceStartup >= goalTime) {
			pauser.unPause ();
			goalTime = -1;
			if (Settings.currentPreferences.enableAI) {
				SceneShift.shiftScene ("Level Select");
			} else {
				SceneShift.shiftScene ("Game Arena");
			}
		}
	}
}
