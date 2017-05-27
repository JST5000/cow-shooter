using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScoreScreen : MonoBehaviour {

	public GameObject scoreScreen;
	public Vector2 center;
	private GameObject scoreScreenInstance;
	private Pause_Game pauser;
	private Countdown gameTimer;
	private Text winner;
	private PvPScore overallCounter;
	private bool hasBeenDisplayed;
	private GameObject canvas;


	// Use this for initialization
	void Start () {
		overallCounter = GameObject.FindGameObjectWithTag ("PvPCounter").GetComponent<PvPScore>();
		hasBeenDisplayed = false;

	}

	void Awake() {
		GameObject global_scripts = GameObject.Find ("Global_Scripts");
		pauser = global_scripts.GetComponent<Pause_Game> ();
		gameTimer = GameObject.Find ("GameTimer").GetComponent<Countdown>();
		canvas = GameObject.Find ("Canvas");
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
		if (scoreScreenInstance == null) {
			scoreScreenInstance = Instantiate(scoreScreen, center, new Quaternion());
			scoreScreenInstance.transform.localScale = new Vector3 (1, 1, 1);
			scoreScreenInstance.transform.SetParent (canvas.transform, false);
			winner = scoreScreenInstance.GetComponentInChildren<Text> ();
			winner.GetComponentInChildren<ScoreboardLogic> ().updateScore ();
		}
		hasBeenDisplayed = true;
	}

	private void displayWinner() {
		float blue = scoreScreen.GetComponentInChildren<ScoreboardLogic> ().blueFinalScore;
		float red = scoreScreen.GetComponentInChildren<ScoreboardLogic> ().redFinalScore;
		if (blue > red) {
			winner.text = "Blue Wins!";
		} else if (red > blue) {
			winner.text = "Red Wins!";
		} else {
			winner.text = "Tie Game!";
		}
	}

	public void removeScore() {
		if (scoreScreenInstance != null) {
			Destroy (scoreScreenInstance);
		} 
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
