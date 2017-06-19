using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : Controls {

	public bool isLeft;

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
