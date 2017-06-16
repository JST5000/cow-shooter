using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : ScriptableObject {

	public string levelName;
	public string levelDescription;
	//public Sprite background; TODO
	public Account enemy;
	public float[] starThresholds;

	public static Level createLevel(string name, Account enemy, float[] starThresholds) {
		Level newLevel = ScriptableObject.CreateInstance<Level> ();
		newLevel.levelName = name;
		newLevel.enemy = enemy;
		newLevel.starThresholds = starThresholds;
		newLevel.levelDescription = "A powerful foe beckons, can you defeat them?";
	//	newLevel.background = TODO
		return newLevel;
	}



}
