using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerControl : MonoBehaviour {

	public float minSpd;
	public float maxSpd;

	private float currSpd;
	private bool increasing;
	private int milliUntilMaxPower;

	// Use this for initialization
	void Start () {
		milliUntilMaxPower = 750;
		resetPower ();
	}

	public void resetPower() {
		increasing = true;
		currSpd = minSpd;
	}

	public float getCurrentSpeed() {
		return currSpd;
	}

	public void changePower() {
		if (increasing) {
			increasePower ();
		} else {
			decreasePower ();
		}
	}

	private void increasePower() {
		float deltaSpd = Time.deltaTime * 1000 / milliUntilMaxPower * (maxSpd - minSpd);
		if(currSpd + deltaSpd > maxSpd)
		{
			currSpd = maxSpd;
			increasing = false;
		} else
		{
			currSpd = currSpd + deltaSpd;
		}
	}

	private void decreasePower() {
		float deltaPower = Time.deltaTime * 1000 / milliUntilMaxPower * (maxSpd - minSpd);
		if(currSpd - deltaPower < minSpd)
		{
			currSpd = minSpd;
			increasing = true;
		} else
		{
			currSpd = currSpd - deltaPower;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
