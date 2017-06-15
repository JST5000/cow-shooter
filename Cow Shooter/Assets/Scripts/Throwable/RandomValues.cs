using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomValues {

	private float notPickedDelta = 1.2f;
	public float initialOdds = 5;
	public float currentOdds;

	public RandomValues(float initOdds) {
		initialOdds = initOdds;
		currentOdds = initialOdds;
	}

	public void wasNotPicked() {
		currentOdds *= notPickedDelta;
	}

	public void wasPicked() {
		currentOdds = initialOdds;
	}
}
