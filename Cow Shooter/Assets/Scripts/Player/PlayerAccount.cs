using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Runtime.Serialization.Formatters.Binary;


public class PlayerAccount : ScriptableObject {

	public PlayerData accountInfo;
	public List<GameObject> throwables = new List<GameObject> ();
	public List<RandomValues> weightedValues = new List<RandomValues> ();
	private string path;

	public static PlayerAccount createPlayerData(string filepath) {
		PlayerAccount instance = ScriptableObject.CreateInstance<PlayerAccount>();
		initializeDefaults (instance);
		instance.path = filepath;
		instance.accountInfo = new PlayerData ();
		instance.accountInfo.throwableNames = getDefaultThrowableNames();
		instance.accountInfo.username = "DEFAULT_NAME";
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

	private static void initializeDefaults(PlayerAccount acc) {
		PlayerData def = new PlayerData ();
		def.username = "DEFAULT_NAME";
		def.throwableNames = getDefaultThrowableNames ();
		acc.throwables = playerDataToGameObjects (def);
	}

	private static List<string> getDefaultThrowableNames() {
		List<string> names = new List<string> ();
		names.Add ("Long-Blue");
		names.Add ("Square-Blue");
		names.Add ("Tetris_T");
		names.Add ("Bomb");
		return names;
	}

	public void setDeck(List<GameObject> deckList) {
		throwables = deckList;
		accountInfo.throwableNames = gameObjectsToNames (deckList);
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

	public static List<GameObject> playerDataToGameObjects(PlayerData info) {
		List<GameObject> deck = new List<GameObject> ();
		string filepath = "Throwable_Prefabs/";
		foreach (string name in info.throwableNames) {
			deck.Add ((GameObject)Resources.Load (filepath + name));
		}
		return deck;
	}

	public static List<string> gameObjectsToNames (List<GameObject> throwables) {
		List<string> names = new List<string> ();
		foreach (GameObject item in throwables) {
			names.Add (item.name);
		}
		return names;
	}

	public static GameObject spawnRandom(Vector2 spawnpoint, bool weighted, PlayerAccount information) {
		if (weighted) {
			if (information.weightedValues.Count < information.throwables.Count) {
				initializeRandomValues (information);
			}
			return weightedSpawn (information, spawnpoint);
		} else {
			return GenerateRandomThrowable.unweightedSpawn (information.throwables, spawnpoint);
		}
	}

	public static void initializeRandomValues (PlayerAccount information) {
		information.weightedValues = new List<RandomValues> ();
		foreach (GameObject throwable in information.throwables) {
			information.weightedValues.Add (new RandomValues (throwable.GetComponent<Randomization> ().baseline));
		}
	}

	private static GameObject weightedSpawn(PlayerAccount information, Vector2 spawnpoint) {
		float totalOdds = 0;
		foreach (RandomValues vals in information.weightedValues) {
			totalOdds += vals.currentOdds;
		}
		float rand = UnityEngine.Random.Range (0, totalOdds);
		int index = 0;
		bool found = false;
		int max = information.weightedValues.Count;
		for (int i = 0; i < max; i++) {
			if (found) {
				information.weightedValues [i].wasNotPicked ();
			} else {
				index = i;
				rand -= information.weightedValues [i].currentOdds;
				if (rand < 0) {
					information.weightedValues [i].wasPicked ();
					found = true;
				} else {
					information.weightedValues [i].wasNotPicked ();
				}
			}
		}
		GameObject throwable = Instantiate(information.throwables[index], spawnpoint, new Quaternion());
		return throwable;
	}
}
