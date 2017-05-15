using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultLogic : MonoBehaviour {

    private bool loaded;
    private bool fire;
    private float power;
    private int maxPower;
    private int milliUntilMaxPower;
    private bool chargingUp;

	// Use this for initialization
	void Start () {
        loaded = false;
        fire = false;
        power = 0;
        maxPower = 100;
        milliUntilMaxPower = 1000;
        chargingUp = false;
	}

	// Update is called once per frame
	void Update () {
		if(!loaded)
        {
            
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

    //TODO
    private void Load()
    {
        //Get random throwable from pool
        //GameObject throwable = 
        //Attach(throwable);
        //loaded = true;
    }

    public void Attach(GameObject throwable)
    {
        FixedJoint2D connection = GetComponent<FixedJoint2D>();
        connection.connectedBody = throwable.GetComponent<Rigidbody2D>();

    }

    //TODO
    private void launchThrowable()
    {

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

    private void OnMouseDown()
    {
        chargingUp = true;
        power = 0;
    }

    private void OnMouseUp()
    {
        chargingUp = false;
        if (loaded)
        {
            fire = true;
        }
    }





    
}
