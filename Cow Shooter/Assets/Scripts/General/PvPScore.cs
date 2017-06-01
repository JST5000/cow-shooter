using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

	void Update() {
		if (SceneManager.GetActiveScene().name != "Game Arena") {
			Destroy (gameObject);
		}
	}

	public string getWinRatioText() {
		return blueWins + " : " + redWins;
	}
}
