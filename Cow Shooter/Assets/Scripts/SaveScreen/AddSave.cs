using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddSave : MonoBehaviour {

	private string username;

	public void submitSave() {
		if (username != null) {
			SaveSlots.currentSaveSlots.addSaveSlot (username);
			GameObject.Find ("SaveSlotsToUIHolder").GetComponent<SaveSlotsToUI> ().updateSaveCarousel ();
			exit ();
		} else {
			print ("No username entered.");
		}
	}

	public void exit() {
		Destroy (gameObject);
	}

	public void setUsername() {
		username = GetComponentInChildren<InputField> ().text;
	}
}
