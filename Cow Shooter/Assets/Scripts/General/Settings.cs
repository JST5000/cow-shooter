using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Settings : MonoBehaviour {

	public static Settings activeSettings;
	public static SettingData currentPreferences;

	private static string fileExtension = "/settings.dat";

	void Awake() {
		Environment.SetEnvironmentVariable ("MONO_REFLECTION_SERIALIZER", "yes");
		if (activeSettings == null) {
			DontDestroyOnLoad (gameObject);
			activeSettings = this;
		}
		if (activeSettings != this) {
			Destroy (gameObject);
		} 
		currentPreferences = loadChanges ();
		if (currentPreferences == null) {
			currentPreferences = new SettingData ();
			copySettingData(currentPreferences, initializeDefaults(new SettingData()));
		}
	}

	private static SettingData initializeDefaults(SettingData defaults) {
		defaults = new SettingData();
		defaults.leftInput = KeyCode.A;
		defaults.rightInput = KeyCode.D;
		defaults.pauseButton = KeyCode.P;
		defaults.gameTimeMinutes = 1;
		defaults.gameTimeSeconds = 0;
		defaults.enableAI = true;
		return defaults;
	}

	public static void saveChanges() {
		if (File.Exists (Application.persistentDataPath + fileExtension)) {
			File.Delete (Application.persistentDataPath + fileExtension);
		}
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = new FileStream (Application.persistentDataPath + fileExtension, FileMode.OpenOrCreate);

		SettingData newSettings = new SettingData ();
		copySettingData (newSettings, currentPreferences);
		bf.Serialize (file, newSettings);
		file.Close ();
	}

	public static SettingData loadChanges() {
		if (File.Exists (Application.persistentDataPath + fileExtension)) {
			FileStream file = File.Open(Application.persistentDataPath + fileExtension, FileMode.Open);
			BinaryFormatter bf = new BinaryFormatter ();
			SettingData newInfo = new SettingData ();
			copySettingData(newInfo, (SettingData)bf.Deserialize (file));
			file.Close ();
			return newInfo;
		}
		return null;
	}

	private static void copySettingData(SettingData destination, SettingData source) {
		destination.leftInput = source.leftInput;
		destination.rightInput = source.rightInput;
		destination.pauseButton = source.pauseButton;
		destination.gameTimeMinutes = source.gameTimeMinutes;
		destination.gameTimeSeconds = source.gameTimeSeconds;
		destination.enableAI = source.enableAI;
	}

	public static void resetData() {
		File.Delete (Application.persistentDataPath + fileExtension);
	}
}
