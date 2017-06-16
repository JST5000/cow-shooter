using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetGoAtApex : MonoBehaviour {

    public EdgeCollider2D topTrigger;
    public EdgeCollider2D bottomTrigger;
    public Collider2D armCollider;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Launch logic = GetComponent<Launch>();
        if (topTrigger.IsTouching(armCollider))
        {
			GetComponentInChildren<Tether> ().releaseTether ();
            GetComponent<Launch>().dropDown();
        }
        if(bottomTrigger.IsTouching(armCollider) && logic.isAtMax)
        {
            logic.isIdle = true;
            logic.isAtMax = false;
        }
    }
}
