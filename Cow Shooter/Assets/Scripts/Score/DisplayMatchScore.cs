using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayMatchScore : MonoBehaviour {

	void Start() {
		checkTally ();
	}

	private void checkTally() {
		if (PvPScore.score != null) {
			GetComponent<Text> ().text = PvPScore.score.blueWins + " : " + PvPScore.score.redWins;
		} else {
			print ("PvPScore.score not initialized yet, hiding match score to avoid user flow being disrupted");
			GetComponent<Text> ().text = "";
		}
			
	}
}
