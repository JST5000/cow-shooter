using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChosenSave : MonoBehaviour {

	public PlayerAccount selectedSave;
	public static ChosenSave chosen;

	// Use this for initialization
	void Start () {
		if (chosen == null) {
			DontDestroyOnLoad (gameObject);
			chosen = this;
		}
		if (chosen != this) {
			Destroy (gameObject);
		} 
	}
}
