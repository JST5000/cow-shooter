using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSlots : MonoBehaviour {

	public List<PlayerAccount> saves;
	public static PlayerAccount currentSave;
	private string startOfName = "/save_";
	private string savesDir = "save_slots";
	private string savesFolder; 
	private string saveInfoLoc; 
	private SaveSlotFileNames info;

	void Awake() {
		savesFolder = Application.persistentDataPath + savesDir;;
		saveInfoLoc = savesFolder + "names_of_saves.dat";

		PlayerAccount defaultAcc = PlayerAccount.createPlayerData (savesFolder + "default.dat");
		currentSave = defaultAcc;

		if (!Directory.Exists (savesFolder)) {
			Directory.CreateDirectory (savesFolder);
		}
		if (File.Exists (saveInfoLoc)) {
			loadAccountInfo ();
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
		string filePath = savesFolder + startOfName + num + ".dat";

		PlayerAccount newSave = PlayerAccount.createPlayerData(filePath);
		newSave.savePlayerData ();

		saves.Add (newSave);
		info.fileNames.Add (filePath);
		saveAccountInfo ();
	}

	public void removeSaveSlot(int index) {
		if (index < saves.Count) {
			PlayerAccount temp = saves [index];
			temp.deleteSave ();
			saves.RemoveAt (index);
			Destroy (temp);
		} else {
			print ("No save of index " + index + " in SaveSlots.saves");
		}
	}

	public void setCurrentSaveSlot(int index) {
		if (index < saves.Count) {
			currentSave = saves [index];
		} else {
			print ("Selected save was outside of the range of current saves with index " + index + ". In SaveSlots.");
		}
	}
}
