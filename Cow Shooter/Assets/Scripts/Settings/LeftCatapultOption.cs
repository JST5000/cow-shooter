using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftCatapultOption : MonoBehaviour {

	private bool readyForNew;

	void Start() {
		displayValue ();
	}

	void Update() {
		if (readyForNew) {
			if (Input.anyKeyDown) {
				Settings.currentPreferences.leftInput = getKeyPressed ();
				readyForNew = false;
				displayValue ();
			}
		}
	}

	public void displayValue() {
		gameObject.GetComponent<Text> ().text = Settings.currentPreferences.leftInput.ToString ();
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
