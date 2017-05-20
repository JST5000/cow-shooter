using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialUI : MonoBehaviour {

	private bool gameStarted;
    public Countdown pregameTimer;
	public Countdown gameTimer;
	public Text pregameMessage;
    
	// Use this for initialization
	void Start () {
		gameTimer.pauseTimer = true;
		gameTimer.GetComponent<Text> ().color = new Color (gameTimer.GetComponentInParent<Text> ().color.r,
			gameTimer.GetComponentInParent<Text> ().color.g, gameTimer.GetComponentInParent<Text> ().color.b, 0f);
		gameStarted = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameStarted && pregameTimer.timesUp) {
			hidePreGame ();
			showTimer ();
			gameStarted = true;
		}
		
	}

	private void hidePreGame() {
		pregameTimer.GetComponent<Text> ().color = new Color (pregameTimer.GetComponent<Text> ().color.r,
			pregameTimer.GetComponent<Text> ().color.g, pregameTimer.GetComponent<Text> ().color.b, 0f);
		pregameMessage.color = new Color (pregameMessage.color.r, pregameMessage.color.g, pregameMessage.color.b, 0f);
	}

	private void showTimer() {
		gameTimer.GetComponentInParent<Text> ().color = new Color (gameTimer.GetComponentInParent<Text> ().color.r,
			gameTimer.GetComponentInParent<Text> ().color.g, gameTimer.GetComponentInParent<Text> ().color.b, 1f);
		gameTimer.pauseTimer = false;
	}
}
