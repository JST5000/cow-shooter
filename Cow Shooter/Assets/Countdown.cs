using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour {

    public int minutes;
    public int seconds;
    public bool pauseTimer;
    public bool timesUp;
    public GameObject timer;
    private float holderUpToASec;

	// Use this for initialization
	void Start () {
        timesUp = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!pauseTimer) {
            holderUpToASec += Time.deltaTime;
            if (holderUpToASec > 1)
            {
                holderUpToASec--;
                reduceByOneSec();
            }
        }
	}

    private void reduceByOneSec()
    {
        if(seconds == 0)
        {
            if(minutes == 0)
            {
                timesUp = true;
            } else
            {
                minutes--;
                seconds = 59;
            }
        } else
        {
            seconds--;
        }
        Text timerText = timer.GetComponent<Text>();
        timerText.text = getText();
    }

    public string getText()
    {
        return "" + minutes + ":" + seconds;
    }

    public void setTime(int min, int sec) 
    {
        minutes = min;
        seconds = sec;
        timesUp = false;
    }
}
