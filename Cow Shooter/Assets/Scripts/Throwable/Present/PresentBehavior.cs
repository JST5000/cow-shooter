using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentBehavior : MonoBehaviour {

	public GameObject throwablePrefabs;
	public GameObject spawnedHolder;

	// Use this for initialization
	void Start () {
		spawnedHolder = GameObject.Find ("ThrowableInstanceHolder");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void rerollCurrentObject() {
		if (GetComponent<Transform>().parent.tag != "ThrowableHolder") {
			GameObject newThrowable = null;
			if (GetComponent<Team> ().team == 0) {
				newThrowable = PlayerAccount.spawnRandom (new Vector2 (), false, SaveSlots.currentSaveSlots.blueTeamSave);
			} else if (GetComponent<Team> ().team == 1) {
				newThrowable = PlayerAccount.spawnRandom (new Vector2 (), false, SaveSlots.currentSaveSlots.redTeamSave);
			} 
			newThrowable.transform.position = gameObject.transform.position;
			newThrowable.transform.rotation = gameObject.transform.rotation;
			newThrowable.transform.parent = spawnedHolder.transform;
			newThrowable.GetComponent<Rigidbody2D> ().velocity = gameObject.GetComponent<Rigidbody2D> ().velocity;
			newThrowable.GetComponent<Rigidbody2D> ().angularVelocity = gameObject.GetComponent<Rigidbody2D> ().angularVelocity;
			newThrowable.GetComponent<Team> ().team = gameObject.GetComponent<Team> ().team;
			newThrowable.GetComponent<FirstCollision> ().startLaunchedTimer ();
			Destroy (gameObject);
		}

	}
}
