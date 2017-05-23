using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentBehavior : MonoBehaviour {

	public GameObject throwablePrefabs;
	public GameObject spawnedHolder;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(2)) {
			rerollCurrentObject ();
		}
	}

	private void rerollCurrentObject() {
		if (GetComponent<Transform>().parent.tag != "ThrowableHolder") {
			GameObject newThrowable = throwablePrefabs.GetComponent<GenerateRandomThrowable> ().
				presentSpawn (gameObject.transform.position, gameObject.transform.rotation, true);
			newThrowable.transform.parent = spawnedHolder.transform;
			newThrowable.GetComponent<Rigidbody2D> ().velocity = gameObject.GetComponent<Rigidbody2D> ().velocity;
			newThrowable.GetComponent<Rigidbody2D> ().angularVelocity = gameObject.GetComponent<Rigidbody2D> ().angularVelocity;
			newThrowable.GetComponent<Team> ().team = gameObject.GetComponent<Team> ().team;
			Destroy (gameObject);
		}

	}
}
