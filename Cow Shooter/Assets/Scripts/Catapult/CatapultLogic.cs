using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultLogic : MonoBehaviour {

    private bool fire;
    public float power;
    private bool loaded;

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
	}

	// Update is called once per frame
	void Update () {
        mouseEvents();
        if(catapultArmLogic.isAtMax)
        {
            power = minPower;
        }
        if(fire)
        {
            launchThrowable();
        }
	}

    private void mouseEvents()
    {
        if (loaded && Input.GetMouseButtonUp(inputMouse) && catapultArmLogic.isIdle)
        {
            launchThrowable();
        }
        if (Input.GetMouseButton(inputMouse) && catapultArmLogic.isIdle && loaded)
        {
            increasePower();
        }
        if(!loaded && Input.GetMouseButtonDown(inputMouse) && catapultArmLogic.isIdle )
        {
            loadCatapult();
        }
        
    }

    private void loadCatapult()
    {
        instantiateRandomThrowable();
        loaded = true;
    }

    private void launchThrowable()
    {
        if (catapultArmLogic.isIdle)
        {
            catapultArmLogic.activate(power);
            loaded = false;
        }
    }

    private void instantiateRandomThrowable()
    {
        List<GameObject> options = new List<GameObject>();
        for (int i = 0; i < throwablePrefabs.transform.childCount; i++)
        {
            options.Add(throwablePrefabs.transform.GetChild(i).gameObject);
        }
        GameObject throwable = Instantiate(options[(int)Random.Range(0, throwablePrefabs.transform.childCount)], spawnpoint, new Quaternion());
        addTeam(throwable);
        throwable.transform.parent = throwableInstanceHolder.transform;
        Vector3 prev = throwable.transform.rotation.eulerAngles;
        if (!catapultArmLogic.isLeftFacing)
        {
            throwable.transform.Rotate(new Vector3(0, 180, 0));
        }
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
        } else
        {
            power = power + deltaPower;
        }
    }

}
