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
        List<GameObject> options = new List<GameObject>();
        for (int i = 0; i < throwablePrefabs.transform.childCount; i++)
        {
            options.Add(throwablePrefabs.transform.GetChild(i).gameObject);
        }
		float totalOdds = 0;
		foreach (GameObject item in options) {
			totalOdds += item.GetComponent<Randomization> ().current;
		}
		float rand = Random.Range (0, totalOdds);
		int index = 0;
		bool found = false;
		for (int i = 0; i < options.Count; i++) {
			if (found) {
				options [i].GetComponent<Randomization> ().wasNotPicked ();
			} else {
				index = i;
				rand -= options [i].GetComponent<Randomization> ().current;
				if (rand < 0) {
					options [i].GetComponent<Randomization> ().wasPicked ();
					found = true;
				} else {
					options [i].GetComponent<Randomization> ().wasNotPicked ();
				}
			}
		}
        GameObject throwable = Instantiate(options[index], spawnpoint, new Quaternion());
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
