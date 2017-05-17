using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetGoAtApex : MonoBehaviour {

    public EdgeCollider2D topTrigger;
    public Collider2D armCollider;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (topTrigger.IsTouching(armCollider))
        {
            GetComponent<Launch>().dropDown();
        }
    }
}
