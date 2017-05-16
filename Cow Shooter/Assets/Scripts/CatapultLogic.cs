using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultLogic : MonoBehaviour {

    private bool fire;
    private float power;
    private int maxPower;
    private int milliUntilMaxPower;
    private bool chargingUp;

    public GameObject catapultArm;
    public Launch catapultArmLogic;
    public GameObject throwablePrefabs;

	// Use this for initialization
	void Start () {
        fire = false;
        power = 0;
        maxPower = 100;
        milliUntilMaxPower = 1000;
        chargingUp = false;
	}

	// Update is called once per frame
	void Update () {
        mouseEvents();
		if(!catapultArmLogic.isIdle)
        {
            
        }
        if(catapultArmLogic.isAtMax)
        {
            catapultArm.GetComponent<FixedJoint2D>().connectedBody = null;
        }
        if(fire)
        {
            launchThrowable();
        }
        if(chargingUp)
        {
            increasePower();
        }
	}

    private void mouseEvents()
    {
        if (Input.GetMouseButton(0) && catapultArmLogic.isIdle)
        {
            loadCatapult();
            launchThrowable();
        }
    }

    private void loadCatapult()
    {
        GameObject randomThrowable = instantiateRandomThrowable();
        catapultArm.AddComponent<FixedJoint2D>();
        FixedJoint2D connection = catapultArm.GetComponent<FixedJoint2D>();
        connection.connectedBody = randomThrowable.GetComponent<Rigidbody2D>();
    }

    //TODO
    private void launchThrowable()
    {
        if (catapultArmLogic.isIdle)
        {
            catapultArmLogic.activate();
        }
    }

    private GameObject instantiateRandomThrowable()
    {
        List<GameObject> options = new List<GameObject>();
        options.Add(throwablePrefabs.transform.GetChild(0).gameObject);
        return Instantiate(options[(int)Random.Range(0, options.Count)], GetComponent<Transform>());
    }

    private void increasePower()
    {

        float deltaPower = Time.deltaTime * 1000 / milliUntilMaxPower * maxPower;
        if(power + deltaPower > maxPower)
        {
            power = maxPower;
        } else
        {
            power = power + deltaPower;
        }
    }

}
