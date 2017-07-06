using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoHolder : MonoBehaviour {

	public Vector2 farthestLeftLoc;
	public float displacement;

	private int maxAmmo;
	private int currentAmmo;

	private GameObject ammoPrefab;
	private GameObject inSceneAmmoHolder;
	private List<GameObject> ammoInstances;

	public bool hasAmmo() {
		return currentAmmo > 0;
	}

	public void useAmmo() {
		currentAmmo--;
		if (currentAmmo < 0) {
			print ("Used ammo while at 0 ammo. Should not have happened");
			currentAmmo = 0;
		}
		updateAmmoUI ();
	}

	public void tryToAddAmmo() {
		currentAmmo++;
		if (currentAmmo > maxAmmo) {
			currentAmmo = maxAmmo;
		}
		updateAmmoUI ();
	}

	// Use this for initialization
	void Start () {
		ammoInstances = new List<GameObject> ();
		maxAmmo = 3;
		inSceneAmmoHolder = GameObject.Find ("AmmoHolder");
		ammoPrefab = (GameObject)Resources.Load ("UI_Prefabs/" + "AmmoIcon");
		instantiateAllAmmoIcons ();
		tryToAddAmmo ();
		addSelfToReloader ();
	}

	private void instantiateAllAmmoIcons() {
		for (int i = 0; i < maxAmmo; i++) {
			ammoInstances.Add (Instantiate (ammoPrefab, inSceneAmmoHolder.transform));
			ammoInstances [i].transform.localPosition = new Vector2 (farthestLeftLoc.x + i * displacement,
				farthestLeftLoc.y);
		}
	}

	private void updateAmmoUI () {
		int counter = currentAmmo;
		foreach (GameObject icon in ammoInstances) {
			SpriteRenderer rend = icon.GetComponent<SpriteRenderer> ();
			float transparency;
			if (counter > 0) {
				transparency = 1f;
				counter--;
			} else {
				transparency = 0;
			}
			rend.color = new Color (rend.color.r, rend.color.g, rend.color.b, transparency);
		}
	}

	private void addSelfToReloader () {
		GameObject.Find ("Loading_Bar/PowerIndicator").GetComponent<MoveLoadingPower> ().ammoStorages.Add (this);
	}

}
                                                                                                    