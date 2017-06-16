using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;


public class PlayerAccount : Account {

	private string path;

	public static PlayerAccount createPlayerData(string filepath) {
		PlayerAccount instance = ScriptableObject.CreateInstance<PlayerAccount>();
		initializeDefaults (instance);
		instance.path = filepath;
		return instance;
	}

	public static PlayerAccount createPlayerData(PlayerData info, string filepath) {
		PlayerAccount instance = ScriptableObject.CreateInstance<PlayerAccount>();
		instance.path = filepath;
		instance.accountInfo = info;
		instance.throwables = playerDataToGameObjects (info);
		return instance;
	}
		
	// Use this for initialization
	void Start () {
		if (accountInfo == null) {
			accountInfo = new PlayerData ();
			initializeDefaults (this);
		}
	}

	public void savePlayerData() {
		BinaryFormatter bf = new BinaryFormatter ();
		FileStream file = new FileStream (path, FileMode.OpenOrCreate);
		bf.Serialize (file, accountInfo);
		file.Close ();
	}

	public void deleteSave() {
		File.Delete (path);
	}

	public static PlayerAccount loadPlayerData(string fileLoc) {
		if (File.Exists (fileLoc)) {
			FileStream file = File.Open (fileLoc, FileMode.Open);
			BinaryFormatter bf = new BinaryFormatter ();
			PlayerData player = (PlayerData)bf.Deserialize (file);
			PlayerAccount loadedAccount = PlayerAccount.createPlayerData (player, fileLoc);
			file.Close ();
			return loadedAccount;
		}
		return null;
	}
		





}
