using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchSim : MonoBehaviour {

	public float simulatedMass;
	public PhysicsMaterial2D simulatedMaterial;
	private float originalMass;
	private PhysicsMaterial2D originalMaterial;

	private GameObject throwable;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void startSim(GameObject newThrow) {
		throwable = newThrow;
		if (throwable != null) {
			originalMass = throwable.GetComponent<Rigidbody2D> ().mass;
			originalMaterial = throwable.GetComponent<Rigidbody2D> ().sharedMaterial;
			throwable.GetComponent<Rigidbody2D> ().mass = simulatedMass;
			throwable.GetComponent<Rigidbody2D> ().sharedMaterial = simulatedMaterial;
		} else {
			print ("NO THROWABLE INSTANTIATED IN LAUNCH SIM. STARTING SIM FAILED AS A RESULT.");
		}
	}

	public void endSim() {
		throwable.GetComponent<Rigidbody2D> ().mass = originalMass;
		throwable.GetComponent<Rigidbody2D> ().sharedMaterial = originalMaterial;
	}
}
