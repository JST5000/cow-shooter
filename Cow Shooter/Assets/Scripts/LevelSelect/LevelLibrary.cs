using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLibrary : MonoBehaviour {

	public static List<Level> allLevels = new List<Level>();

	// Use this for initialization
	void Awake () {
		loadLevels ();
	}
	
	private void loadLevels() {
		loadPirate ();
		loadKid ();
		for (int i = 0; i < 13; i++) {
			loadFiller (i); //This is to make the UI testable before we complete all levels
		}
	}

	private void loadPirate() {
		string name = "Pirate";
		PlayerData data = new PlayerData ();
		data.throwableNames.Add ("Bomb");
		data.throwableNames.Add ("Anchor");
		data.throwableNames.Add ("FlatScreen");

		Account enemy = Account.createAccount (data);

		float[] thresholds = { 0f, 15f, 30f };

		Level newLevel = Level.createLevel (name, enemy, thresholds);
		allLevels.Add (newLevel);
	}

	private void loadKid() {
		string name = "Kid";
		PlayerData data = new PlayerData ();
		data.throwableNames.Add ("BouncyHouse");
		data.throwableNames.Add ("Teddy");
		data.throwableNames.Add ("Present");

		Account enemy = Account.createAccount (data);

		float[] thresholds = { 0f, 20f, 40f };

		Level newLevel = Level.createLevel (name, enemy, thresholds);
		allLevels.Add (newLevel);
	}

	private void loadFiller(int index) {
		string name = "FILLER LEVEL " + index;
		PlayerData data = new PlayerData ();
		data.throwableNames.Add ("Tetris_T");
		data.throwableNames.Add ("Long-Blue");
		data.throwableNames.Add ("Square-Blue");

		Account enemy = Account.createAccount (data);

		float[] thresholds = { 0f, 20f, 40f };

		Level newLevel = Level.createLevel (name, enemy, thresholds);
		allLevels.Add (newLevel);
	}


}