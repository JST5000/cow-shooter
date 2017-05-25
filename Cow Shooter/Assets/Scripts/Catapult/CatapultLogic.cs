using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultLogic : MonoBehaviour {

    private bool fire;
    public float power;
    public bool loaded;
	private bool powerIncreasing;

	public float simulatedMass;
	private GameObject loadedThrowable;
	private float loadedMass;

    private int milliUntilMaxPower;

    public GameObject catapultArm;
    public Launch catapultArmLogic;
    public GameObject throwablePrefabs;
    public Vector3 spawnpoint;
    public int inputMouse;
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
	}

	// Update is called once per frame
	void Update () {
        if (Time.timeScale != 0)
        {
            mouseEvents();
            if (catapultArmLogic.isAtMax)
            {
                power = minPower;
				if (loadedThrowable != null) {
					loadedThrowable.GetComponent<Rigidbody2D> ().mass = loadedMass;
					FirstCollision temp = loadedThrowable.GetComponent<FirstCollision> ();
					if (temp != null) {
						temp.startLaunchedTimer();
					}
				}
            }
            if (fire)
            {
                launchThrowable();
            }
        }
	}

    private void mouseEvents()
    {

        if (loaded && Input.GetMouseButtonUp(inputMouse) && catapultArmLogic.isIdle)
        {
            launchThrowable();
        }
        if (Input.GetMouseButton(inputMouse) && loaded)
        {
			if (powerIncreasing) {
				increasePower ();
			} else {
				decreasePower ();
			}
        }
        
    }

    public void loadCatapult()
    {
		loadedThrowable = instantiateRandomThrowable();
		loadedMass = loadedThrowable.GetComponent<Rigidbody2D> ().mass;
		loadedThrowable.GetComponent<Rigidbody2D> ().mass = simulatedMass;
		loaded = true;
    }

	public bool canLoad() {
		return catapultArmLogic.isIdle;
	}

	public void replaceThrowable() {
		Destroy (loadedThrowable);
		loadCatapult ();
	}

    private void launchThrowable()
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
        if (!catapultArmLogic.isLeftFacing)
        {
            throwable.transform.Rotate(new Vector3(0, 180, 0));
        }
		return throwable;
    }


    private void addTeam(GameObject throwable)
    {
        Team ally = throwable.GetComponent<Team>();
        if (catapultArmLogic.isLeftFacing)
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
