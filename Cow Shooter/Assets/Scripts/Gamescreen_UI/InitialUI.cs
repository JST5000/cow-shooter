using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitialUI : MonoBehaviour {

	public Countdown gameTimer;
	public GameObject pregameMessage;
	public Canvas canvas;

	private bool gamePlaying;
    private Countdown pregameTimer;
	private GameObject pregameInstantiation;
 
	// Use this for initialization
	void Start () {
		pregameInstantiation = Instantiate (pregameMessage, new Vector2(0, 2), new Quaternion());
		pregameInstantiation.transform.SetParent(canvas.transform, false);
		pregameInstantiation.transform.localScale = new Vector3 (1, 1, 1);
		pregameTimer = pregameInstantiation.GetComponentInChildren<Countdown> ();
		gameTimer.pauseTimer = true;
		gameTimer.GetComponent<Text> ().color = new Color (gameTimer.GetComponentInParent<Text> ().color.r,
			gameTimer.GetComponentInParent<Text> ().color.g, gameTimer.GetComponentInParent<Text> ().color.b, 0f);
		gamePlaying = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!gamePlaying && pregameTimer.timesUp) {
			destroyPreGame ();
			showTimer ();
			gamePlaying = true;
		}
		if (gamePlaying && gameTimer.timesUp) {
			gameOver ();
		}
		
	}

	public bool isGamePlaying() {
		return gamePlaying;
	}

	public void gameOver() {
		gamePlaying = false;
	}

	private void destroyPreGame() {
		Destroy (pregameInstantiation.gameObject);
	}

	private void showTimer() {
		gameTimer.GetComponentInParent<Text> ().color = new Color (gameTimer.GetComponentInParent<Text> ().color.r,
			gameTimer.GetComponentInParent<Text> ().color.g, gameTimer.GetComponentInParent<Text> ().color.b, 1f);
		gameTimer.pauseTimer = false;
	}
}
