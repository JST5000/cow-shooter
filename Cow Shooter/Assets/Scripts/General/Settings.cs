using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Settings : MonoBehaviour {

	public static Settings activeSettings;
	private static SettingData defaults;
	public static SettingData currentPreferences;

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
		currentPreferences = loadChanges ();
		if (currentPreferences == null) {
			currentPreferences = defaults;
		}
	}

	private void initializeDefaults() {
		defaults = new SettingData();
		defaults.leftInput = KeyCode.A;
		defaults.rightInput = KeyCode.D;
		defaults.pauseButton = KeyCode.P;
		defaults.gameTimeMinutes = 1;
		defaults.gameTimeSeconds = 0;
		defaults.enableAI = true;
	}

	public void saveChanges() {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = new FileStream (Application.persistentDataPath + fileExtension, FileMode.Open);

		SettingData newSettings = new SettingData ();
		newSettings.leftInput = currentPreferences.leftInput;
		newSettings.rightInput = currentPreferences.rightInput;
		newSettings.pauseButton = currentPreferences.pauseButton;
		newSettings.gameTimeMinutes = currentPreferences.gameTimeMinutes;
		newSettings.gameTimeSeconds = currentPreferences.gameTimeSeconds;
		newSettings.enableAI = currentPreferences.enableAI;

		bf.Serialize (file, newSettings);
		file.Close ();
	}

	public SettingData loadChanges() {
		if (File.Exists (Application.persistentDataPath + fileExtension)) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open(Application.persistentDataPath + fileExtension, FileMode.Open);
			SettingData prevInfo = (SettingData)bf.Deserialize (file);
			currentPreferences.leftInput = prevInfo.leftInput;
			currentPreferences.rightInput = prevInfo.rightInput;
			currentPreferences.pauseButton = prevInfo.pauseButton;
			currentPreferences.gameTimeMinutes = prevInfo.gameTimeMinutes;
			currentPreferences.gameTimeSeconds = prevInfo.gameTimeSeconds;
			currentPreferences.enableAI = prevInfo.enableAI;

			return prevInfo;
		}
		return null;
	}
}
