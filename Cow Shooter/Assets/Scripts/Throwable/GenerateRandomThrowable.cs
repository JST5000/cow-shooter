using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRandomThrowable : MonoBehaviour {

	public GameObject spawnEntityAt(Vector3 spawnpoint, int index) {
		List<GameObject> options = new List<GameObject>();
		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			options.Add(gameObject.transform.GetChild(i).gameObject);
		}
		return Instantiate(options[index], spawnpoint, new Quaternion());
	}

	public GameObject presentSpawn(Vector3 spawnpoint, Quaternion rot, bool weightedRandom) {
		List<GameObject> options = new List<GameObject>();
		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			options.Add(gameObject.transform.GetChild(i).gameObject);
		}
		int index = Random.Range (0, options.Count);
		while (!Equals (options [index].GetComponent<PresentBehavior> (), null)) {
			index = Random.Range (0, options.Count);
		}
		GameObject throwable = Instantiate(options[index], spawnpoint, rot);
		return throwable;
	}

	public GameObject spawnRandomizedThrowable(Vector3 spawnpoint, bool weightedRandom) {
		List<GameObject> options = new List<GameObject>();
		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			options.Add(gameObject.transform.GetChild(i).gameObject);
		}
		if (weightedRandom) {
			return weightedSpawn (options, spawnpoint);
		} else {
			return unweightedSpawn (options, spawnpoint);
		}
	}

	private GameObject weightedSpawn(List<GameObject> options, Vector3 spawnpoint) {
		float totalOdds = 0;
		foreach (GameObject item in options) {
			totalOdds += item.GetComponent<Randomization> ().current;
		}
		float rand = Random.Range (0, totalOdds);
		int index = 0;
		bool found = false;
		for (int i = 0; i < options.Count; i++) {
			if (found) {
				options [i].GetComponent<Randomization> ().wasNotPicked ();
			} else {
				index = i;
				rand -= options [i].GetComponent<Randomization> ().current;
				if (rand < 0) {
					options [i].GetComponent<Randomization> ().wasPicked ();
					found = true;
				} else {
					options [i].GetComponent<Randomization> ().wasNotPicked ();
				}
			}
		}
		GameObject throwable = Instantiate(options[index], spawnpoint, new Quaternion());
		return throwable;
	}

	private GameObject unweightedSpawn(List<GameObject> options, Vector3 spawnpoint) {
		int index = Random.Range (0, options.Count);
		GameObject throwable = Instantiate(options[index], spawnpoint, new Quaternion());
		return throwable;
	}
}
