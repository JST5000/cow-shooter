using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerData : MonoBehaviour {

	public string username;
	public SettingData playerSettings;
	public List<GameObject> throwables = new List<GameObject>();

	/*
	 * Players have the following:
	 * Settings
	 * Character
	 * Campaign Progress
	 * Lists of throwables
	 * 
	 */
}
