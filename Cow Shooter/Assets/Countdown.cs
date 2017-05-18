using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour {

    public int minutes;
    public int seconds;
    private float totalTimeElapsed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        totalTimeElapsed += Time.deltaTime;
	}
}
