using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvPScore : MonoBehaviour {

	public int blueWins;
	public int redWins;

	void Awake() {
		if (GameObject.FindGameObjectsWithTag("PvPCounter").Length > 1) {
			Destroy (gameObject);
		}
	}

	void Start() {
		DontDestroyOnLoad (gameObject);
	}

	public string getWinRatioText() {
		return blueWins + " : " + redWins;
	}
}
