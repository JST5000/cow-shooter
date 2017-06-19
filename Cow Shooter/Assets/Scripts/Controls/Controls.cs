using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls {

	public virtual bool inputDown() {
		return false;
	}

	public virtual bool inputContinuous() {
		return false;
	}

	public virtual bool inputUp() {
		return false;
	}
}
