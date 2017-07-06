using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PositiveFeedback : MonoBehaviour {

	public static List<string> positivePhrases;
	public static GameObject feedbackPrefab;

	// Use this for initialization
	void Start () {
		positivePhrases = new List<string> ();
		positivePhrases.Add ("Amazing!");
		positivePhrases.Add ("Wow!");
		positivePhrases.Add ("Spectacular!");
		positivePhrases.Add ("Wild!");
		positivePhrases.Add ("Great!");
		positivePhrases.Add ("Crazy Play!");
		feedbackPrefab = (GameObject)Resources.Load ("UI_Prefabs/" + "Feedback");
	}
	
	public static void spawnPositiveFeedback(Vector2 spawnpoint) {
		GameObject instance = Instantiate (feedbackPrefab, GameObject.Find ("Canvas").transform);
		instance.GetComponent<Text> ().text = getRandomPhrase ();
		instance.transform.position = spawnpoint;
	}

	public static string getRandomPhrase() {
		int index = Random.Range (0, positivePhrases.Count);
		return positivePhrases [index];
	}
}
