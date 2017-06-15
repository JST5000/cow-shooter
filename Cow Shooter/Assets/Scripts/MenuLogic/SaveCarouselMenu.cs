using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCarouselMenu : MonoBehaviour {

	private SaveSlotsToUI saveUI;
	private string instanceName = "";

	void Awake() {
		saveUI = GameObject.Find ("SaveSlotsToUIHolder").GetComponent<SaveSlotsToUI> ();
	}

	public void openAddSaveMenu() {
		if (GameObject.Find (instanceName) == null) {
			GameObject addSaveMenu = (GameObject)Resources.Load ("UI_Prefabs/AddSaveMenu");
			GameObject instance = Instantiate (addSaveMenu, GameObject.Find ("Canvas").transform);
			instance.transform.position = new Vector2 (0, 0);
			instance.transform.localScale = new Vector2 (1, 1);
			instanceName = instance.name;
		}
	}

	public void destroySelectedSave() {
		SaveSlots.currentSaveSlots.removeChosen ();
		saveUI.updateSaveCarousel ();
	}

	public void back() {
		SceneShift.shiftScene ("Main Menu");
	}

	public void editSelectedSave() {
		//TODO
	}

	public void moveLeft() {
		saveUI.changeCenter (false);
	}

	public void moveRight() {
		saveUI.changeCenter (true);
	}

	public void playWithSelectedSave() {
		if (SaveSlots.currentSaveSlots.chosenSave != null) {
			SaveSlots.currentSaveSlots.blueTeamSave = SaveSlots.currentSaveSlots.chosenSave;
			SaveSlots.currentSaveSlots.redTeamSave = SaveSlots.currentSaveSlots.chosenSave;
			SceneShift.shiftScene ("Game Arena");
		}
	}

}
