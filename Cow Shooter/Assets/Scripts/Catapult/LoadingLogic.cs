using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingLogic : MonoBehaviour {

	public float loadingTime;
	public float timeElapsed;
	public CatapultLogic catapult;
	private bool tryToLoad;

	// Use this for initialization
	void Start () {
		tryToLoad = false;
	}
	
	// Update is called once per frame
	void Update () {
		updateTime ();
		if (tryToLoad) {
			tryToloadCatapult ();
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
				catapult.replaceThrowable ();
			} else {
				catapult.loadCatapult ();
			}
			tryToLoad = false;
		}
	}
}
