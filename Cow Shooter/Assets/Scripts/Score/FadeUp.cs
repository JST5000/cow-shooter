using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeUp : MonoBehaviour {

	public float duration;
	public float distance;
	public float delay;
	private Text txt;


	void Start() {
		txt = GetComponent<Text> ();
	}

	// Update is called once per frame
	void Update () {
		if (delay > 0) {
			delay -= Time.deltaTime;
		} else {
			gameObject.transform.position = (Vector2)gameObject.transform.position + new Vector2 (0, distance / duration * Time.deltaTime);
			txt.color = new Color (txt.color.r, txt.color.g, txt.color.b, txt.color.a - (Time.deltaTime / duration));
			if (txt.color.a <= 0) {
				Destroy (gameObject);
			}
		}
	}
}
