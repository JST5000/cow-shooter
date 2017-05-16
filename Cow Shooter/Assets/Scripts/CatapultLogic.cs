using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultLogic : MonoBehaviour {

    private bool fire;
    private float power;

    private int milliUntilMaxPower;
    private bool chargingUp;
    private GameObject loadedObject;
    private float x_mult;
    private float y_mult;

    public GameObject catapultArm;
    public Launch catapultArmLogic;
    public GameObject throwablePrefabs;
    public Vector3 spawnpoint;
    public int inputMouse;
    public float minPower;
    public float maxPower;

    // Use this for initialization
    void Start () {
        fire = false;
        power = minPower;
        milliUntilMaxPower = 1000;
        chargingUp = false;
        float direction;
        if (catapultArmLogic.isLeftFacing)
        {
           direction = Mathf.Deg2Rad * catapultArmLogic.max_rot;
        } else
        {
           direction = Mathf.Deg2Rad * (180 - catapultArmLogic.max_rot);
        }
        x_mult = Mathf.Cos(direction);
        y_mult = Mathf.Sin(direction);
	}

	// Update is called once per frame
	void Update () {
        mouseEvents();
        if(!catapultArmLogic.isAtMax && !catapultArmLogic.isIdle)
        {
            loadedObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(power * x_mult, power * y_mult));
            print(power);
        }
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
        if (Input.GetMouseButtonUp(inputMouse) && catapultArmLogic.isIdle)
        {
            loadCatapult();
            launchThrowable();
        }
        if (Input.GetMouseButton(inputMouse) && catapultArmLogic.isIdle)
        {
            increasePower();
        }
        
    }

    private void loadCatapult()
    {
        loadedObject = instantiateRandomThrowable();
    }

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
        return Instantiate(options[(int)Random.Range(0, options.Count)], spawnpoint, new Quaternion());
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
