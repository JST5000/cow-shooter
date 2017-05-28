using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour {

    public bool isLeft;
    public bool isIdle;
    public bool isAtMax;
    public Rigidbody2D arm;
    public float power;
    public float returnPower;

    // Use this for initialization
    void Start()
    {
        isAtMax = false;
        isIdle = true;
    }
    private void FixedUpdate()
    {
        if (!isIdle && !isAtMax)
        {
            rotateToMax();
        }
        if (isAtMax)
        {
            rotateToGround();
        }
    }

    private void rotateToMax()
    {
        if(isLeft)
        {
            arm.AddTorque(-power);
        } else
        {
            arm.AddTorque(power);
        }
    }

    private void rotateToGround()
    {
        if (isLeft)
        {
            arm.AddTorque(returnPower);
        }
        else
        {
            arm.AddTorque(-returnPower);
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
