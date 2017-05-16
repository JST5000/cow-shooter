using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour {

    private Transform rotator;
    private Vector3 vel;
    public float max_rot;
    private float current_rot;
    public float min_rot;
    public bool isLeftFacing;
    private int direction;
    public bool isIdle;
    public bool isAtMax;


    // Use this for initialization
    void Start()
    {
        isAtMax = false;
        current_rot = 0;
        rotator = GetComponent<Transform>();
        if (isLeftFacing)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
        vel = new Vector3(0, 0, 2);
        isIdle = true;
    }

    // Update is called once per frame
    void Update()
    {
        int input_type = 1; //rmb
        if(isLeftFacing)
        {
            input_type = 0; //lmb
        }
        if (Input.GetMouseButtonDown(input_type) && isIdle)
        {
            activate();
        }
        if (!isIdle)
        {
            rotateToMax();
        }
    }

    private void rotateToMax()
    {
        if (isLeftFacing)
        {
            current_rot += -1 * direction * vel.z;
        } else
        {
            current_rot += direction * vel.z;
        }
        if (current_rot > max_rot)
        {
            isAtMax = true;
            direction = -direction;
        }
        if (current_rot <= min_rot)
        {
            isAtMax = false;
            isIdle = true;
            direction = -direction;
        }
        rotator.Rotate(direction * vel);
        
    }

    public void activate()
    {
        isIdle = false;
    }


}
