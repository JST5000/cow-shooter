using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveSlotsToUI : MonoBehaviour {

	public Vector2 center;
	public Vector2 displacement;
	private List<GameObject> saveCarousel;
	private GameObject saveUI;
	private const int onScreenCap = 3;
	public int indexOfCenter = 0;

	void Start() {
		saveCarousel = new List<GameObject> ();
		saveUI = (GameObject)Resources.Load ("UI_Prefabs/SaveSlotUI");
		updateSaveCarousel ();
	}

	public void updateSaveCarousel() {
		int start = Mathf.Min (SaveSlots.currentSaveSlots.saves.Count, onScreenCap - saveCarousel.Count) - 1;
		for (int i = start; i >= 0; i--) {
			PlayerAccount save = SaveSlots.currentSaveSlots.saves [i];
			GameObject display = Instantiate (saveUI, GameObject.Find("CarouselMenu").transform);
			display.GetComponent<SaveToUI> ().adoptSave (save);
			saveCarousel.Add (display);
		}
		cullExtra ();
		if (indexOfCenter > SaveSlots.currentSaveSlots.saves.Count) {
			indexOfCenter = SaveSlots.currentSaveSlots.saves.Count - 1;
		}
		assignSaveIdentities ();
		setCarouselLocations();
	}

	private void cullExtra() {
		while (saveCarousel.Count > SaveSlots.currentSaveSlots.saves.Count) {
			GameObject saveUI = saveCarousel [0];
			saveCarousel.RemoveAt (0);
			Destroy (saveUI);
		}
	}

	private void assignSaveIdentities() {
		int[] saveIndexes = positionsAroundCenter ();
		int max = saveCarousel.Count;
		for (int i = 0; i < max; i++) {
			saveCarousel [i].GetComponent<SaveToUI> ().adoptSave(SaveSlots.currentSaveSlots.saves[saveIndexes [i]]);
		}
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

	private int[] positionsAroundCenter() {
		int[] surrounding = {0, 0, 0};
		int max = SaveSlots.currentSaveSlots.saves.Count - 1;
		if (indexOfCenter == 0) {
			surrounding [0] = max;
			surrounding [1] = indexOfCenter;
			surrounding [2] = indexOfCenter + 1;
		} else if (indexOfCenter == max) {
			surrounding [0] = indexOfCenter - 1;
			surrounding [1] = indexOfCenter;
			surrounding [2] = 0;
		} else {
			surrounding [0] = indexOfCenter - 1;
			surrounding [1] = indexOfCenter;
			surrounding [2] = indexOfCenter + 1;
		}
		return surrounding;
	}

	public void changeCenter(bool right) {
		int max = SaveSlots.currentSaveSlots.saves.Count - 1;
		if (right) {
			if (indexOfCenter == max) {
				indexOfCenter = 0;
			} else {
				indexOfCenter++;
			}
		} else {
			if (indexOfCenter == 0) {
				indexOfCenter = max;
			} else {
				indexOfCenter--;
			}
		}
		updateSaveCarousel ();
	}
}
