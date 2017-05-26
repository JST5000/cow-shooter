using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartGame : MonoBehaviour {

	public Countdown gameTimer;
	public PvPScore overallScore;
	public ScoreboardLogic score;
	public SceneShift shift;
	public Pause_Game pauser;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && gameTimer.timesUp) {
			pauser.unPause ();
			shift.shiftScene ("Game Arena");
		}
	}
}
