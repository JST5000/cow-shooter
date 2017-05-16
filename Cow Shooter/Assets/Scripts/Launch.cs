using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launch : MonoBehaviour {

    private Transform rotator;
    private bool positivity;
    public Vector3 vel;
    public float max_rot;
    public float min_rot;
    public bool counterclockwise;


    // Use this for initialization
    void Start()
    {
        rotator = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        positivity = vel.z < 0;
        if(counterclockwise)
        {
            if ((positivity && rotator.rotation.eulerAngles.z > max_rot) || (!positivity && rotator.rotation.eulerAngles.z < min_rot))
            {
                vel = new Vector3(0, 0, -vel.z);
            }
        } 
        rotator.Rotate(vel);
    }
}
