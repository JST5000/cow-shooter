using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveToUI : MonoBehaviour {

	private PlayerAccount save;
	private bool hidden = true;

	void Update() {
		if (hidden && SaveSlots.currentSaveSlots.chosenSave != null &&
				SaveSlots.currentSaveSlots.chosenSave.accountInfo.username == save.accountInfo.username) {
			showSelectionBox ();
			hidden = false;
		} else if(!hidden && SaveSlots.currentSaveSlots.chosenSave != null && SaveSlots.currentSaveSlots.chosenSave.accountInfo.username != save.accountInfo.username) {
			hideSelectionBox ();
			hidden = true;
		}
	}

	public void adoptSave(PlayerAccount newSave) {
		save = newSave;
		Text[] items = GetComponentsInChildren<Text> ();
		foreach (Text item in items) {
			if (item.gameObject.name == "SaveName") {
				item.text = save.accountInfo.username;
			}
			if (item.gameObject.name == "CampaignPercent") {
				item.text = LevelLibrary.getScorePercent(save.accountInfo.scores.highScores) + "%";
			}
		}

	}

	public void onClick() {
		if (save != null) {
			SaveSlots.currentSaveSlots.chosenSave = save;
		} else {
			print ("Tried to set save, but there was no save attached to this SaveToUI");
		}
	}

	private void showSelectionBox() {
		GetComponentInChildren<SelectionLogic> ().turnSelectionBoxOn ();
	}

	private void hideSelectionBox() {
		GetComponentInChildren<SelectionLogic> ().turnSelectionBoxOff ();
	}
}
