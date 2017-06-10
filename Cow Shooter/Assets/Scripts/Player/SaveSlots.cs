using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSlots : MonoBehaviour {

	public List<PlayerAccount> saves;
	private string startOfName = "/save_";
	private string savesDir = "save_slots";
	private string savesFolder; 
	private string saveInfoLoc; 
	private SaveSlotFileNames info;

	void Awake() {
		savesFolder = Application.persistentDataPath + savesDir;;
		saveInfoLoc = savesFolder + "names_of_saves.dat";

		if (!Directory.Exists (savesFolder)) {
			Directory.CreateDirectory (savesFolder);
		}
		if (File.Exists (saveInfoLoc)) {
			//load
		} else {
			info = new SaveSlotFileNames ();
			saveAccountInfo ();
		}
	}

	private void saveAccountInfo() {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = new FileStream (saveInfoLoc, FileMode.OpenOrCreate);
		bf.Serialize (file, info);
		file.Close ();
	}

	private void loadAccountInfo() {
		
		if (File.Exists (saveInfoLoc)) {
			FileStream file = File.Open(saveInfoLoc, FileMode.Open);
			BinaryFormatter bf = new BinaryFormatter ();
			SaveSlotFileNames listOfAccounts = (SaveSlotFileNames)bf.Deserialize (file);
			file.Close ();
			info = listOfAccounts;
			foreach (string loc in info.fileNames) {
				if(File.Exists(loc)) {
					saves.Add(PlayerAccount.loadPlayerData(loc));
					info.fileNames.Add(loc);
				} else {
					print("Tried to load a save file that does not exist at " + loc + ". The error is in Save Slots.cs");
				}
			}
			saveAccountInfo();
		}

	}

	public void updateSave(int index) {
		if (index < saves.Count) {
			saves [index].savePlayerData ();
		} else {
			print ("File does not exist with index " + index + " in saves of SaveSlots so save could not be updated");
		}
	}

	public void addSaveSlot() {
		int num = saves.Count;
		string filePath = savesFolder + startOfName + num;

		PlayerAccount newSave = new PlayerAccount (filePath);
		newSave.savePlayerData ();

		saves.Add (newSave);
		info.fileNames.Add (filePath);
		saveAccountInfo ();
	}
}
