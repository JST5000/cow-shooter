using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DisplayOptionValue : MonoBehaviour {

	public string optionName;
	public GameObject display;

	public virtual void displayValue() {

	}

	public virtual void changeValue() {

	}
}
