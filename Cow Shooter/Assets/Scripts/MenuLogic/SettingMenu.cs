using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenu : MonoBehaviour {



	public void toggleAI() {
		Settings.currentPreferences.enableAI = !Settings.currentPreferences.enableAI;
	}

	public void apply() {
		Settings.saveChanges ();
	}

	public void reset() {
		Settings.loadChanges ();
	}

	public void destroySelf() {
		Destroy (gameObject);
	}
}
