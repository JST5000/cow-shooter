using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelToUI : MonoBehaviour {

	public Level lvl;

	public void adoptLevel(Level designated, int index) {
		lvl = designated;
		checkPreviousHighScores ();
		updateDisplayNumber (index);
	}

	private void checkPreviousHighScores() {
		if (SaveSlots.currentSaveSlots == null) {
			setStars (0);
		} else {
			bool found = false;
			foreach (Score scr in SaveSlots.currentSaveSlots.chosenSave.accountInfo.scores.highScores) {
				if (scr.levelName == lvl.levelName) {
					int stars = 0;
					foreach (float goal in lvl.starThresholds) {
						if (scr.score > goal) {
							stars++;
						}
					}
					setStars (stars);
					found = true;
					break;
				}
			}
			if (!found) {
				setStars (0);
			}
		}
	}

	private void setStars(int starCount) {
		int goldStars = starCount;
		foreach (StarToggle star in GetComponentsInChildren<StarToggle>()) {
			if (goldStars > 0) {
				star.giveGoldStar ();
				goldStars--;
			} else {
				star.giveEmptyStar ();
			}
		}
	}

	private void updateDisplayNumber(int index) {
		GetComponentInChildren<Text> ().text = ""+index;
	}

	public void onClick() {
		LevelLoader.chosenLevel = lvl;
		SceneShift.shiftScene ("Game Arena");
	}
}
