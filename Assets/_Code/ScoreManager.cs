using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int totalScore;
    public event System.Action<int> ScoreUpdatedEvent;

	// Use this for initialization
	void Start ()
    {
    
	}
	
	// Update is called once per frame
	void Update ()
    {

	}

    public void AddPoints(int points)
    {
        totalScore += points;
        if (ScoreUpdatedEvent != null)
        {
            ScoreUpdatedEvent(totalScore);
        }
    }

    public int GetTotalScore()
    {
        return totalScore;
    }
}
