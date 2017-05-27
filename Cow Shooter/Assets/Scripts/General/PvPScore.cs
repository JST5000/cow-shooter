using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PvPScore : MonoBehaviour {

	public static PvPScore score;
	public int blueWins;
	public int redWins;

	void Awake() {
		if (score == null) {
			DontDestroyOnLoad (gameObject);
			score = this;
		}
		if (score != this) {
			Destroy (gameObject);
		}
	}

	void Start() {
	}

	public string getWinRatioText() {
		return blueWins + " : " + redWins;
	}
}
