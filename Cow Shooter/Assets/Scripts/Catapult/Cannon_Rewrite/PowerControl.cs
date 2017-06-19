using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerControl {

	public float min;
	public float max;

	private float curr;
	private bool increasing;
	private int milliUntilMaxPower;

	// Use this for initialization
	void Start () {
		milliUntilMaxPower = 750;
		resetPower ();
	}

	public void resetPower() {
		increasing = true;
		curr = min;
	}

	public float getCurrent() {
		return curr;
	}

	public float getCurrentPercent() {
		return (curr - min) / (max - min) * 100;
	}

	public void changePower() {
		if (increasing) {
			increasePower ();
		} else {
			decreasePower ();
		}
	}

	private void increasePower() {
		float delta = Time.deltaTime * 1000 / milliUntilMaxPower * (max - min);
		if(curr + delta > max)
		{
			curr = max;
			increasing = false;
		} else
		{
			curr = curr + delta;
		}
	}

	private void decreasePower() {
		float deltaPower = Time.deltaTime * 1000 / milliUntilMaxPower * (max - min);
		if(curr - deltaPower < min)
		{
			curr = min;
			increasing = true;
		} else
		{
			curr = curr - deltaPower;
		}
	}
}
