﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;


public class PlayerAccount : MonoBehaviour {

	public PlayerData accountInfo;
	private string path;

	public PlayerAccount(string filepath) {
		path = filepath;
	}

	public PlayerAccount(PlayerData info, string origPath) {
		accountInfo = info;
		path = origPath;
	}

	// Use this for initialization
	void Start () {
		if (accountInfo == null) {
			accountInfo = new PlayerData ();
			foreach (GameObject item in getDefaultThrowables()) {
				accountInfo.throwables.Add (item); 
			}
		}
	}

	private List<GameObject> getDefaultThrowables() {
		string folder = "Throwable_Prefabs/";
		List<GameObject> defaultDeck = new List<GameObject> ();
		defaultDeck.Add ((GameObject)Resources.Load (folder + "Tetris_L"));
		defaultDeck.Add ((GameObject)Resources.Load (folder + "Tetris_Square"));
		defaultDeck.Add ((GameObject)Resources.Load (folder + "Tetris_T"));
		defaultDeck.Add ((GameObject)Resources.Load (folder + "Bomb"));
		return defaultDeck;
	}

	public void setDeck(List<GameObject> deckList) {
		accountInfo.throwables = deckList;
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
			PlayerAccount loadedAccount = new PlayerAccount (player, fileLoc);
			file.Close ();
			return loadedAccount;
		} else {
			print ("FILE NOT FOUND AT " + fileLoc + "\n Error is in PlayerAccount.loadPlayerData(fileLoc)");
		}
		return null;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
