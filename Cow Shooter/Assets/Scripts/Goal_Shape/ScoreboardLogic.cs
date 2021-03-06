﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardLogic : MonoBehaviour {
    private GameObject holder;
    public float updateDelay;
    private float updateCount;
    public int blueFinalScore;
    public int redFinalScore;
    public int boardSize;
    // Use this for initialization
    void Start () {
		initialize ();
    }
	
	// Update is called once per frame
	void Update () {
        updateCount += Time.deltaTime;
        if (updateCount > updateDelay)
        {
            updateScore();
            updateCount = 0;
        }
	}

	public void initialize() {
		GameObject tempObject = GameObject.Find("Targets");
		PointCalculator calculator = tempObject.GetComponent<PointCalculator>();
		boardSize = calculator.size;
		blueFinalScore = 0;
		redFinalScore = 0;
		holder = GameObject.Find("ThrowableInstanceHolder");
	}

    public void updateScore()
    {
		initialize ();
        InsideChecker[] pointTotals = holder.GetComponentsInChildren<InsideChecker>();
        foreach(InsideChecker checker in pointTotals)
        {
            if (checker.team == 0) //blue
            {
                blueFinalScore += checker.score;
            }
            else if(checker.team == 1) //red
            {
                redFinalScore += checker.score;
            }
    
        }
        //print("BlueScore="+ ((double)blueFinalScore /boardSize)*100+" RedScore="+(((double)redFinalScore)/boardSize)*100);
        GetComponent<Text>().text = getText(blueFinalScore, redFinalScore);
    }

    private string getText(double blueFinalScore, double redFinalScore)
    {
        string output = "Blue Score is ";
        output += (int)(((double)blueFinalScore / boardSize) * 100);
        output += "%\nRedScore is ";
        output += (int)((((double)redFinalScore) / boardSize) * 100);
        output += "%";
        return output;
    }
}
