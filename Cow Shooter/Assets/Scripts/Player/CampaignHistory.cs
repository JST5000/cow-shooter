using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CampaignHistory {

	public List<Score> highScores = new List<Score>();

	public void updateScore(Score result) {
		foreach (Score scr in highScores) {
			if (scr.levelName == result.levelName) {
				if (scr.score < result.score) {
					scr.score = result.score;
				}
				return;
			}
		}
		highScores.Add (result);
	}

}
