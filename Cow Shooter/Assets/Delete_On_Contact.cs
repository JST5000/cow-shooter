using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete_On_Contact : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Should delete all objects that collide with it.
        ContactFilter2D all = new ContactFilter2D();
        all.NoFilter();
        Collider2D[] overlapping = null;
        int size = gameObject.GetComponent<Collider2D>().OverlapCollider(all, overlapping);
        for (int i = 0; i < size; i++)
        {
             Destroy(overlapping[i].gameObject);   
        }
    }
}
