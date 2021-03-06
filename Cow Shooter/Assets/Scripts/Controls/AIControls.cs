﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControls : Controls {
	
	public float maxRotPercent = 80;
	public float minRotPercent = 20;

	public float maxVelPercent = 70;
	public float minVelPercent = 20;

	private float goalVel = -1;
	private float goalRot = -1;

	private float currVel;
	private float currRot;

	private float velTolerance;
	private float rotTolerance;

	public override bool inputDown() {
		return isNearGoalRot();
	}

	public override bool inputContinuous() {
		return (isNearGoalRot() && !isNearGoalVel());
	}

	public override bool inputUp() {
		bool output = isNearGoalRot() && isNearGoalVel();
		if (output) {
			goalVel = getRandomPercent (minVelPercent, maxVelPercent);
			goalRot = getRandomPercent (minRotPercent, maxRotPercent);
			currVel = -1;
			currRot = -1;
		} 
		return output;
	}

	public override void informAI (float velPercent, float rotPercent)
	{
		if (goalVel < 0) {
			goalVel = getRandomPercent (minVelPercent, maxVelPercent);
		} 
		if (goalRot < 0) {
			goalRot = getRandomPercent (minRotPercent, minRotPercent);
		}
		currVel = velPercent;
		currRot = rotPercent;

		velTolerance = .1f * (maxVelPercent - minVelPercent);
		rotTolerance = .1f * (maxRotPercent - minRotPercent);
	}

	private bool isNearGoalRot() {
		return isWithinTolerance(goalRot, currRot, rotTolerance);
	}

	private bool isNearGoalVel() {
		return isWithinTolerance (goalVel, currVel, velTolerance);
	}

	private bool isWithinTolerance(float first, float second, float tolerance) {
		return (Mathf.Abs (first - second) <= tolerance);
	}

	private float getRandomPercent(float min, float max) { 
		return Random.Range (min, max);
	}
}
