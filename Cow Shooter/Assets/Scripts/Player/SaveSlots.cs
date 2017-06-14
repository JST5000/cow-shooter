using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSlots : MonoBehaviour {

	public List<PlayerAccount> saves;
	public PlayerAccount chosenSave;

	public static SaveSlots currentSaveSlots;

	private string startOfName = "/save_";
	private string savesDir = "save_slots";
	private string savesFolder; 
	private string saveInfoLoc; 
	private SaveSlotFileNames info;

	void Awake() {
		savesFolder = Application.persistentDataPath + savesDir;
		saveInfoLoc = savesFolder +"/" + "names_of_saves.dat";

		haveOneInstance ();

		if (!Directory.Exists (savesFolder)) {
			Directory.CreateDirectory (savesFolder);
		}
		if (File.Exists (saveInfoLoc)) {
			loadAccountInfo ();
		} else {
			print ("DID NOT FIND INDEX. Made a new one.");
			info = new SaveSlotFileNames ();
			saveAccountInfo ();
		}
	}

	private void haveOneInstance() {
		if (currentSaveSlots == null) {
			DontDestroyOnLoad (gameObject);
			currentSaveSlots = this;
		}
		if (currentSaveSlots != this) {
			Destroy (gameObject);
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
				} else {
					print("Tried to load a save file that does not exist at " + loc);
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

	public void addSaveSlot(string username) {
		int num = saves.Count;
		string filePath = savesFolder + startOfName + username + ".dat";

		PlayerAccount newSave = PlayerAccount.createPlayerData(filePath);
		newSave.accountInfo.username = username;
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
			print (info.fileNames [index]);
			info.fileNames.RemoveAt (index);
			saveAccountInfo ();
			Destroy (temp);
		} else {
			print ("No save of index " + index + " in SaveSlots.saves");
		}
	}

	public void removeChosen() {
		if (chosenSave != null) {
			int index = saves.IndexOf (chosenSave);
			print (index);
			removeSaveSlot (index);
		}
	}
}
