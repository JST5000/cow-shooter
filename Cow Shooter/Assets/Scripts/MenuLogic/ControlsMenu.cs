using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsMenu : MonoBehaviour {

	public void alterLeftBind() {
		while(!Input.anyKeyDown) {
		}
		Settings.currentPreferences.leftInput = getKeyPressed ();
	}

	public void alterRightBind() {
		while (!Input.anyKeyDown) {
		}
		Settings.currentPreferences.rightInput = getKeyPressed ();
	}

	public void alterPauseButton() {
		while (!Input.anyKeyDown) {
		}
		Settings.currentPreferences.pauseButton = getKeyPressed ();
	}

	public void destroySelf() {
		Destroy (gameObject);
	}

	public void apply() {
		Settings.saveChanges ();
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
