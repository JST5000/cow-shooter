using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause_Game : MonoBehaviour {

    public Text pauseMessage;
    public Image pauseBackground;

	// Use this for initialization
	void Start () {
        pauseMessage.color = new Color(pauseMessage.color.r, pauseMessage.color.g, pauseMessage.color.b, 0f);
        pauseBackground.color = new Color(pauseBackground.color.r, pauseBackground.color.g, pauseBackground.color.b, 0f);
    }

    public void pause() {
        Time.timeScale = 0;
    }

	public void showPauseMessage() {
		pauseMessage.color = new Color(pauseMessage.color.r, pauseMessage.color.g, pauseMessage.color.b, 1f);
		pauseBackground.color = new Color(pauseBackground.color.r, pauseBackground.color.g, pauseBackground.color.b, 1f);
	}

	public void hidePauseMessage() {
		pauseMessage.color = new Color(pauseMessage.color.r, pauseMessage.color.g, pauseMessage.color.b, 0f);
		pauseBackground.color = new Color(pauseBackground.color.r, pauseBackground.color.g, pauseBackground.color.b, 0f);
	}

    public void unPause()
    {
        Time.timeScale = 1;
    }
}
