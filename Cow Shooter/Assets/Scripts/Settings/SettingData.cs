using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SettingData {


	public KeyCode leftInput = KeyCode.A;
	public KeyCode rightInput = KeyCode.D;
	public KeyCode pauseButton = KeyCode.P;
	public int gameTimeMinutes = 1;
	public int gameTimeSeconds = 0;
	public bool enableAI = true;

	//public Vector3 magicNumber = new Vector3(10, 42, 9421); 


}
