using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentBehavior : MonoBehaviour {

	public GameObject throwablePrefabs;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(2)) {
			print ("Trying to reroll");
			rerollCurrentObject ();
		}
	}

	private void rerollCurrentObject() {
		if (GetComponent<Transform>().parent.tag != "ThrowableHolder") {
			GameObject newThrowable = throwablePrefabs.GetComponent<GenerateRandomThrowable> ().
				spawnRandomizedThrowable (gameObject.transform.position, true);
			int i = 10;
			while (!Equals(newThrowable.GetComponent<PresentBehavior> (), null)) {
				if (i <= 0) {
					newThrowable = throwablePrefabs.GetComponent<GenerateRandomThrowable> ().spawnDefault (gameObject.transform.position);
				} else {
					i--;
				}
			}

			Destroy (gameObject);
		}

	}
}
