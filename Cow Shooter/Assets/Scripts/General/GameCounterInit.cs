using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCounterInit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (Settings.currentPreferences != null) {
			GetComponent<Countdown> ().minutes = Settings.currentPreferences.gameTimeMinutes;
			GetComponent<Countdown> ().seconds = Settings.currentPreferences.gameTimeSeconds;
		} else {
			print ("Settings not found using default of counter time set on gametimer");
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
