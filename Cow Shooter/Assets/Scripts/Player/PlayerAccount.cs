using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAccount : MonoBehaviour {

	public string username;
	public PlayerData save;

	// Use this for initialization
	void Start () {
		if (save == null) {
			save = new PlayerData ();
			save.addThrowables (getDefaultThrowables());
		}
	}

	private List<GameObject> getDefaultThrowables() {
		string folder = "Throwable_Prefabs/";
		List<GameObject> defaultPackage = new List<GameObject> ();
		defaultPackage.Add ((GameObject)Resources.Load (folder + "Tetris_L"));
		defaultPackage.Add ((GameObject)Resources.Load (folder + "Tetris_Square"));
		defaultPackage.Add ((GameObject)Resources.Load (folder + "Tetris_T"));
		defaultPackage.Add ((GameObject)Resources.Load (folder + "Bomb"));

		return defaultPackage;
	}


	
	// Update is called once per frame
	void Update () {
		
	}
}
