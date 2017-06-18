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
		
		GameObject newThrowable = null;
		if (GetComponent<Team> ().team == 0) {
			newThrowable = Account.presentSpawnRandom (new Vector2 (), new Quaternion (), false, SaveSlots.currentSaveSlots.blueTeamSave);
		} else if (GetComponent<Team> ().team == 1) {
			newThrowable = Account.presentSpawnRandom (new Vector2 (), new Quaternion (), false, SaveSlots.currentSaveSlots.redTeamSave);
		} 
		newThrowable.transform.position = gameObject.transform.position;
		newThrowable.transform.rotation = gameObject.transform.rotation;
		newThrowable.transform.parent = spawnedHolder.transform;
		newThrowable.GetComponent<Rigidbody2D> ().velocity = gameObject.GetComponent<Rigidbody2D> ().velocity;
		newThrowable.GetComponent<Rigidbody2D> ().angularVelocity = gameObject.GetComponent<Rigidbody2D> ().angularVelocity;
		newThrowable.GetComponent<Team> ().team = gameObject.GetComponent<Team> ().team;
		newThrowable.GetComponent<FirstCollision> ().collidedAfterLaunch = true;
		newThrowable.GetComponent<FirstCollision> ().onFirstCollision();
		Destroy (gameObject);

	}
}
