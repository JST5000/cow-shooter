﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultLogic : MonoBehaviour {

    private bool fire;
    public float power;
    public bool loaded;
	private bool powerIncreasing;


	public OneWayWalls gate;

	private GameObject loadedThrowable;


    private int milliUntilMaxPower;

    public GameObject catapultArm;
    public Launch catapultArmLogic;
    public GameObject throwablePrefabs;
    public Vector3 spawnpoint;
    public float minPower;
    public float maxPower;
    public GameObject throwableInstanceHolder;

    // Use this for initialization
    void Start () {
        fire = false;
        loaded = false;
        power = minPower;
        milliUntilMaxPower = 750;
		powerIncreasing = true;
		GameObject settings = GameObject.Find ("SettingsHolder");
		if (settings == null) {
			print ("Settings not found, using default controls set locally in catapult logic.");
		}
	}

	private bool getInput() {
		if (Settings.currentPreferences != null) {
			if (catapultArmLogic.isLeft) {
				return Input.GetKey(Settings.currentPreferences.leftInput);
			} else {
				return Input.GetKey(Settings.currentPreferences.rightInput);
			}
		} else {
			if (catapultArmLogic.isLeft) {
				return Input.GetKey(KeyCode.A);
			} else {
				return Input.GetKey(KeyCode.D);
			}
		}
	}

	private bool getInputUp() {
		if (Settings.currentPreferences != null) {
			if (catapultArmLogic.isLeft) {
				return Input.GetKeyUp(Settings.currentPreferences.leftInput);
			} else {
				return Input.GetKeyUp(Settings.currentPreferences.rightInput);
			}
		} else {
			if (catapultArmLogic.isLeft) {
				return Input.GetKeyUp(KeyCode.A);
			} else {
				return Input.GetKeyUp(KeyCode.D);
			}
		}
	}

	// Update is called once per frame
	void Update () {
        if (Time.timeScale != 0) //not paused
        {
            checkInputs();
			atApexLogic ();
            if (fire)
            {
                launchThrowable();
            }
        }
	}

    private void checkInputs()
    {

		if (loaded && catapultArmLogic.isIdle && getInputUp())
        {
            launchThrowable();
        }
		if (loaded && getInput())
        {
			if (powerIncreasing) {
				increasePower ();
			} else {
				decreasePower ();
			}
        }
        
    }

	private void atApexLogic() {
		if (catapultArmLogic.isAtMax)
		{
			power = minPower;
			if (loadedThrowable != null) {
				GetComponent<LaunchSim> ().endSim ();
				FirstCollision temp = loadedThrowable.GetComponent<FirstCollision> ();
				if (temp != null) {
					temp.startLaunchedTimer();
				}
			}
		}
	}

    public void loadCatapult()
    {
		loadedThrowable = instantiateRandomThrowable();
		GetComponent<LaunchSim> ().startSim (loadedThrowable);
		gate.ignoreCollisionWith (loadedThrowable.GetComponent<Collider2D> ());
		loaded = true;
    }

	public bool canLoad() {
		return catapultArmLogic.isIdle;
	}

	public void replaceThrowable() {
		Destroy (loadedThrowable);
		loadCatapult ();
	}

    public void launchThrowable()
    {
        if (catapultArmLogic.isIdle)
        {
            catapultArmLogic.activate(power);
            loaded = false;
			powerIncreasing = true;
        }
    }

	private GameObject instantiateRandomThrowable()
    {
		GameObject throwable = throwablePrefabs.GetComponent<GenerateRandomThrowable> ().spawnRandomizedThrowable (spawnpoint, true);
        addTeam(throwable);
        throwable.transform.parent = throwableInstanceHolder.transform;
        Vector3 prev = throwable.transform.rotation.eulerAngles;
        if (!catapultArmLogic.isLeft)
        {
            throwable.transform.Rotate(new Vector3(0, 180, 0));
        }
		return throwable;
    }


    private void addTeam(GameObject throwable)
    {
        Team ally = throwable.GetComponent<Team>();
        if (catapultArmLogic.isLeft)
        {
            ally.team = 0; //blue
        }
        else
        {
            ally.team = 1; //red
        }
    }

    private void increasePower()
    {
        float deltaPower = Time.deltaTime * 1000 / milliUntilMaxPower * (maxPower - minPower);
        if(power + deltaPower > maxPower)
        {
            power = maxPower;
			powerIncreasing = false;
        } else
        {
            power = power + deltaPower;
        }
    }

	private void decreasePower() {
		float deltaPower = Time.deltaTime * 1000 / milliUntilMaxPower * (maxPower - minPower);
		if(power - deltaPower < minPower)
		{
			power = minPower;
			powerIncreasing = true;
		} else
		{
			power = power - deltaPower;
		}
	
	}

}
