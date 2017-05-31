using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightCatapultOption : MonoBehaviour {

	private bool readyForNew;

	void Awake() {
		displayValue ();
	}

	void Update() {
		if (readyForNew) {
			if (Input.anyKeyDown) {
				Settings.currentPreferences.rightInput = getKeyPressed ();
				readyForNew = false;
				displayValue ();
			}
		}
	}

	public void displayValue() {
		gameObject.GetComponent<Text> ().text = Settings.currentPreferences.rightInput.ToString ();
	}

	public void alterValue() {
		readyForNew = true;
	}

	private KeyCode getKeyPressed() {

		foreach(KeyCode vKey in System.Enum.GetValues(typeof(KeyCode))){
			if(Input.GetKey(vKey)){
				return vKey;
			}
		}
		print ("No key was pressed");
		return KeyCode.Space;
	}
}
