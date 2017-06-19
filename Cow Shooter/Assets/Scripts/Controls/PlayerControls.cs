using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : Controls {

	public bool isLeft;

	public override bool inputDown() {
		if (isLeft) {
			return Input.GetKeyDown (Settings.currentPreferences.leftInput);
		} else {
			return Input.GetKeyDown (Settings.currentPreferences.rightInput);
		}
	}

	public override bool inputContinuous() {
		if (isLeft) {
			return Input.GetKey (Settings.currentPreferences.leftInput);
		} else {
			return Input.GetKey (Settings.currentPreferences.rightInput);
		}
	}

	public override bool inputUp() {
		if (isLeft) {
			return Input.GetKeyUp (Settings.currentPreferences.leftInput);
		} else {
			return Input.GetKeyUp (Settings.currentPreferences.rightInput);
		}
	}
}
