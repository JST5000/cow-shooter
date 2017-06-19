using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControls : Controls {

	public float maxRotPercent;
	public float minRotPercent;
	public float maxVelPercent;
	public float minVelPercent;

	private float goalVel;
	private float goalRot;

	//TODO
	public override bool inputDown() {
		return false;
	}

	public override bool inputContinuous() {
		return false;
	}

	public override bool inputUp() {
		return false;
	}
}
