using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randomization : MonoBehaviour {

	[Range(1, 10)]
	public float baseline;
	public float current;
	private float notPickedDelta;

	void Start() {
		notPickedDelta = 1.2f;
		current = baseline;
	}

	public void wasPicked() {
		current = baseline;
	}

	public void wasNotPicked() {
		current *= notPickedDelta;
	}
}
