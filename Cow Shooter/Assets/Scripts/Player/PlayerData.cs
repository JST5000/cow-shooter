using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

	public Settings playerSettings;
	private List<GameObject> throwables;

	void Awake() {
		throwables = new List<GameObject> ();
	}

	public void addThrowable(GameObject newThrowable) {
		throwables.Add (newThrowable);
	}

	public void addThrowables(List<GameObject> newThrowables) {
		foreach (GameObject entry in newThrowables) {
			addThrowable (entry);
		}
	}

	public GameObject spawnRandom(Vector2 spawnpoint, bool weighted) {
		if (weighted) {
			return GenerateRandomThrowable.weightedSpawn (throwables, spawnpoint);
		} else {
			return GenerateRandomThrowable.unweightedSpawn (throwables, spawnpoint);
		}
	}

	/*
	 * Players have the following:
	 * Settings
	 * Character
	 * Campaign Progress
	 * Lists of throwables
	 * 
	 */
}
