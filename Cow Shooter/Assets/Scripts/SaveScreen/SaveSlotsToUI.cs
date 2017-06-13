using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSlotsToUI : MonoBehaviour {

	public Vector2 center;
	public Vector2 displacement;
	private List<GameObject> saveCarousel;
	private GameObject saveUI;

	void Start() {
		saveCarousel = new List<GameObject> ();
		saveUI = (GameObject)Resources.Load ("UI_Prefabs/SaveSlotUI");
		updateSaveCarousel ();
	}

	public void updateSaveCarousel() {
		SaveSlots saveStorage = GetComponent<SaveSlots> ();
		foreach (PlayerAccount save in saveStorage.saves) {
			GameObject display = Instantiate (saveUI);
			display.GetComponent<SaveToUI> ().adoptSave (save);
			saveCarousel.Add (display);
		}
		setCarouselLocations();
	}

	private void setCarouselLocations() {
		if (saveCarousel.Count >= 3) {
			for (int i = 0; i < 3; i++) {
				Vector2 localPosition = center + Vector2.Scale (new Vector2(i - 1f, 1f), displacement);
				saveCarousel [i].transform.position = localPosition;
			}
		} else if (saveCarousel.Count == 2) {
			for (int i = 0; i < 2; i++) {
				Vector2 localPosition = center + Vector2.Scale (new Vector2(i - .5f, 1f), displacement);
				saveCarousel [i].transform.position = localPosition;
			}
		} else if (saveCarousel.Count == 1) {
			saveCarousel [0].transform.position = center;
		}
	}
}
