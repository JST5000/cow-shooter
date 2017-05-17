using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour {

    public bool isLeftFacing;
    public bool isIdle;
    public bool isAtMax;
    public Rigidbody2D arm;
    public float power;

    // Use this for initialization
    void Start()
    {
        isAtMax = false;
        isIdle = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isIdle)
        {
            rotateToMax();
        }
        if(arm.rotation <= 0 && isAtMax) 
        {
            isAtMax = false;
            isIdle = true;
        }
    }

    private void rotateToMax()
    {
        if(isLeftFacing)
        {
            arm.AddTorque(power);
        } else
        {
            arm.AddTorque(-power);
        }
    }

    public void activate(float pow)
    {
        power = pow;
        isIdle = false;
    }
    
    public void dropDown()
    {
        isAtMax = true;
    }
}
