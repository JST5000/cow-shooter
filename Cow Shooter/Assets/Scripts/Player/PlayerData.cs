using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerData : MonoBehaviour {

	public string username;
	public Settings playerSettings;
	public List<GameObject> throwables = new List<GameObject>();

/*

	public static GameObject spawnRandom(Vector2 spawnpoint, bool weighted, PlayerData information) {
		if (weighted) {
			return GenerateRandomThrowable.weightedSpawn (throwables, spawnpoint);
		} else {
			return GenerateRandomThrowable.unweightedSpawn (throwables, spawnpoint);
		}
	}
	*/

	/*
	 * Players have the following:
	 * Settings
	 * Character
	 * Campaign Progress
	 * Lists of throwables
	 * 
	 */
}
