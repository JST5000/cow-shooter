using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Settings : MonoBehaviour {

	public static Settings activeSettings;
	private static SettingData defaults;

	public KeyCode leftInput;
	public KeyCode rightInput;
	public KeyCode pauseButton;
	public int gameTimeMinutes;
	public int gameTimeSeconds;

	private string fileExtension = "/settings.dat";

	void Awake() {
		if (activeSettings == null) {
			DontDestroyOnLoad (gameObject);
			activeSettings = this;
		}
		if (activeSettings != this) {
			Destroy (gameObject);
		}
		initializeDefaults ();
		if (!loadChanges ()) {
			loadDefaults ();
		}
	}

	private void initializeDefaults() {
		defaults = new SettingData();
		defaults.leftInput = KeyCode.A;
		defaults.rightInput = KeyCode.D;
		defaults.pauseButton = KeyCode.P;
		defaults.gameTimeMinutes = 1;
		defaults.gameTimeSeconds = 0;
	}

	private void loadDefaults() {
		leftInput = defaults.leftInput;
		rightInput = defaults.rightInput;
		pauseButton = defaults.pauseButton;
		gameTimeMinutes = defaults.gameTimeMinutes;
		gameTimeSeconds = defaults.gameTimeSeconds;
	}

	public void saveChanges() {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = new FileStream (Application.persistentDataPath + fileExtension, FileMode.Open);

		SettingData newSettings = new SettingData ();
		newSettings.leftInput = leftInput;
		newSettings.rightInput = rightInput;
		newSettings.pauseButton = pauseButton;
		newSettings.gameTimeMinutes = gameTimeMinutes;
		newSettings.gameTimeSeconds = gameTimeSeconds;

		bf.Serialize (file, newSettings);
		file.Close ();
	}

	public bool loadChanges() {
		if (File.Exists (Application.persistentDataPath + fileExtension)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open(Application.persistentDataPath + fileExtension, FileMode.Open);
			SettingData prevInfo = (SettingData)bf.Deserialize (file);
			leftInput = prevInfo.leftInput;
			rightInput = prevInfo.rightInput;
			pauseButton = prevInfo.pauseButton;
			gameTimeMinutes = prevInfo.gameTimeMinutes;
			gameTimeSeconds = prevInfo.gameTimeSeconds;
			return true;
		}
		return false;
	}

	[Serializable]
	class SettingData {
		public KeyCode leftInput = KeyCode.A;
		public KeyCode rightInput = KeyCode.D;
		public KeyCode pauseButton = KeyCode.P;
		public int gameTimeMinutes = 1;
		public int gameTimeSeconds = 0;
	}
}
