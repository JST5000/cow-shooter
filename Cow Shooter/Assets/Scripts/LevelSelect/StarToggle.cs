using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarToggle : MonoBehaviour {

	public Sprite filled;
	public Sprite empty;

	public void giveGoldStar() {
		GetComponent<Image> ().sprite = filled;
	}

	public void giveEmptyStar() {
		GetComponent<Image> ().sprite = empty;
	}
}
