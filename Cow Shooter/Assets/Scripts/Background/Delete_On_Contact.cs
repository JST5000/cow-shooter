using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete_On_Contact : MonoBehaviour {

	public Collider2D hitbox;

	private void OnTriggerEnter2D(Collider2D col)
	{
		Destroy (col.gameObject);
	}
}
