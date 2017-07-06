using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerData {

	public string username;
	public List<string> throwableNames = new List<string>();
	public CampaignHistory scores = new CampaignHistory ();

	/*
	 * Players have the following:
	 * Character
	 * Campaign Progress
	 * Lists of throwables
	 * 
	 */
}
