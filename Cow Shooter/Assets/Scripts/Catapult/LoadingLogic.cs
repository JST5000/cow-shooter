﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingLogic : MonoBehaviour {

	public bool replaceMode;

	public float loadingTime;
	public float timeElapsed;
	public CatapultLogic catapult;
	private bool tryToLoad;

	// Use this for initialization
	void Start () {
		tryToLoad = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<InitialUI> ().isGamePlaying() && !GetComponent<InitialUI>().gameTimer.timesUp) {
			updateTime ();
			if (tryToLoad) {
				tryToloadCatapult ();
			}
		}
	}

	private void updateTime() {
		timeElapsed += Time.deltaTime;
		if (timeElapsed > loadingTime) {
			timeElapsed -= loadingTime;
			tryToLoad = true;
		}
	}

	private void tryToloadCatapult() {
		if (catapult.canLoad ()) {
			if (catapult.loaded) {
				if (replaceMode) {
					catapult.replaceThrowable ();
					tryToLoad = false;
				} else {
					catapult.launchThrowable ();
				}
			} else {
				catapult.loadCatapult ();
				tryToLoad = false;
			}
		}
	}
}
