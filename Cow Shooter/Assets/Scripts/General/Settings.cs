using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {

	public static Settings activeSettings;

	public KeyCode leftInput = KeyCode.A;
	public KeyCode rightInput = KeyCode.D;
	public KeyCode pauseButton = KeyCode.P;
	public int gameTimeMinutes = 1;
	public int gameTimeSeconds = 0;

	void Awake() {
		if (activeSettings == null) {
			DontDestroyOnLoad (gameObject);
			activeSettings = this;
		}
		if (activeSettings != this) {
			Destroy (gameObject);
		}
	}

	void Start() {
		loadChanges ();
	}

	public void saveChanges() {
		//TODO
	}

	public void loadChanges() {
		//TODO
	}
}
