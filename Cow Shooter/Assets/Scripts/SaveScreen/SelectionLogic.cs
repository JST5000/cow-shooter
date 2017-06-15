using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionLogic : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		turnSelectionBoxOff ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void turnSelectionBoxOn() {
		GetComponent<Image> ().color = new Color (GetComponent<Image> ().color.r, 
			GetComponent<Image> ().color.g, GetComponent<Image> ().color.b, 1);
	}

	public void turnSelectionBoxOff() {
		GetComponent<Image> ().color = new Color (GetComponent<Image> ().color.r, 
			GetComponent<Image> ().color.g, GetComponent<Image> ().color.b, 0);
	}
}
