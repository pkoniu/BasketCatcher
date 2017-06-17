using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Text scoreLabel;
    private ScoreManager scoreManager;
    public AbstractTweener tweener;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void UpdateScore(int score)
    {
        //scoreLabel.transform.DOPunchScale(new Vector3(1.2f,1.2f,1.2f), 0.3f, 1, 0);
        if (tweener)
        {
            tweener.Tween(scoreLabel.transform);
        }

        scoreLabel.text = "PKonior, Score: " + score.ToString();
    }

    private void Awake()
    {
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }

    private void OnEnable()
    {
        scoreManager.ScoreUpdatedEvent += ScoreChangedEventHandler;
    }

    private void OnDisable()
    {
        scoreManager.ScoreUpdatedEvent -= ScoreChangedEventHandler;
    }

    void ScoreChangedEventHandler(int newScore)
    {
        UpdateScore(scoreManager.GetTotalScore());
    }
}
