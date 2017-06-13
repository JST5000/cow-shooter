using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveToUI : MonoBehaviour {

	private PlayerAccount save;

	public void adoptSave(PlayerAccount newSave) {
		save = newSave;
		Text[] items = GetComponentsInChildren<Text> ();
		foreach (Text item in items) {
			if (item.gameObject.name == "SaveName") {
				item.text = save.accountInfo.username;
			}
			if (item.gameObject.name == "CampaignPercent") {
				item.text = "-1%";
				//item.text = save.accountInfo.campaignPercent;
			}
		}

	}

	public void onClick() {
		if (save != null) {
			ChosenSave.chosen.selectedSave = save;

		} else {
			print ("Tried to set save, but there was no save attached to this SaveToUI");
		}
	}
}
