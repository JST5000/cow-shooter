using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreboardLogic : MonoBehaviour {
    GameObject holder;
    public float updateDelay;
    private float updateCount;
    public int blueFinalScore;
    public int redFinalScore;
    public int boardSize;
    // Use this for initialization
    void Start () {
        GameObject tempObject = GameObject.Find("BackgroundTarget");
        PointCalculator calculator = tempObject.GetComponent<PointCalculator>();
        boardSize = calculator.size;
        blueFinalScore = 0;
        redFinalScore = 0;
        holder =GameObject.Find("ThrowableInstanceHolder");
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
    void updateScore()
    {
        blueFinalScore = 0;
        redFinalScore = 0;
        InsideChecker[] pointTotals = holder.GetComponentsInChildren<InsideChecker>();
        foreach(InsideChecker checker in pointTotals)
        {
            if (checker.team == Team.suggestedTeams.Blue)
            {
                blueFinalScore += checker.score;
            }
            else
            {
                redFinalScore += checker.score;
            }
    
        }
        print("BlueScore="+ ((double)blueFinalScore /boardSize)*100+" RedScore="+(((double)redFinalScore)/boardSize)*100);
        
    }
}
