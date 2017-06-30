using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//PatrykKonior

public class ScoreManager : MonoBehaviour
{

    private int totalScore;

    public int lives = 10;

    public event System.Action<int> ScoreUpdatedEvent;
    public event System.Action<int> LivesUpdatedEvent;

    public void AddPoints(int points)
    {
        totalScore += points;
        if (ScoreUpdatedEvent != null)
            ScoreUpdatedEvent(totalScore);
    }

    public int GetTotalScore()
    {
        return totalScore;
    }

    public void LoseLife()
    {
        lives--;
        if (LivesUpdatedEvent != null)
            LivesUpdatedEvent(lives);

        if (lives <= 0)
        {
            BasketCatcherCore.instance.SubmitScore(totalScore);
            SceneSwitcher.LoadHighScores();
        }
    }
}
