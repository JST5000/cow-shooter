using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScoreScreen : MonoBehaviour {

	public GameObject scoreScreen;
	public Pause_Game pauser;
	public Countdown gameTimer;
	public Text winner;
	private PvPScore overallCounter;
	private bool hasBeenDisplayed;


	// Use this for initialization
	void Start () {
		overallCounter = GameObject.FindGameObjectWithTag ("PvPCounter").GetComponent<PvPScore>();
		hasBeenDisplayed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasBeenDisplayed && gameTimer.timesUp) {
			hideGameTimer ();
			displayScore ();
			displayWinner ();
			updatePvPCounter ();
		}
	}

	public void displayScore() {
		pauser.pause ();
		scoreScreen.transform.position = new Vector2 (0, 0);
		hasBeenDisplayed = true;
	}

	private void displayWinner() {
		float blue = scoreScreen.GetComponentInChildren<ScoreboardLogic> ().blueFinalScore;
		float red = scoreScreen.GetComponentInChildren<ScoreboardLogic> ().redFinalScore;
		if (blue > red) {
			winner.text = "BLUE TEAM!";
		} else if (red > blue) {
			winner.text = "RED TEAM!";
		} else {
			winner.text = "BOTH OF YOU! TIE GAME";
		}
	}

	public void removeScore() {
		scoreScreen.transform.position = new Vector2 (0, 500);
	}

	private void hideGameTimer() {
		gameTimer.GetComponent<Text> ().color = new Color (gameTimer.GetComponent<Text> ().color.r, gameTimer.GetComponent<Text> ().color.g,
			gameTimer.GetComponent<Text> ().color.b, 0);
	}

	private void updatePvPCounter() {
		float blue = scoreScreen.GetComponentInChildren<ScoreboardLogic> ().blueFinalScore;
		float red = scoreScreen.GetComponentInChildren<ScoreboardLogic> ().redFinalScore;
		if (blue > red) {
			overallCounter.blueWins++;
		} else if (red > blue) {
			overallCounter.redWins++;
		} else {
			overallCounter.blueWins++;
			overallCounter.redWins++;
		}
	}

	private void showGameTimer() {
		gameTimer.GetComponent<Text> ().color = new Color (gameTimer.GetComponent<Text> ().color.r, gameTimer.GetComponent<Text> ().color.g,
			gameTimer.GetComponent<Text> ().color.b, 1);
	}
}
