using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

//PatrykKonior

public class HUD : MonoBehaviour
{

    ScoreManager scoreManager;

    [SerializeField]
    Text text;

    [SerializeField]
    Text livesText;

    [SerializeField]
    Button backButton;

    public AbstractTweener tweener;

    void Awake()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        backButton.onClick.AddListener(BackButtonHandler);
    }

    private void BackButtonHandler()
    {
        SceneSwitcher.LoadMainMenu();
    }

    void OnEnable()
    {
        scoreManager.ScoreUpdatedEvent += UpdateScore;
        scoreManager.LivesUpdatedEvent += UpdateLives;
        UpdateScore(scoreManager.GetTotalScore());
        UpdateLives(scoreManager.lives);
    }

    void OnDisable()
    {
        scoreManager.ScoreUpdatedEvent -= UpdateScore;
        scoreManager.LivesUpdatedEvent -= UpdateLives;
    }

    private void UpdateLives(int lives)
    {
        livesText.text = "Lives: " + String.Concat(Enumerable.Repeat("♥", lives).ToArray());
    }

    void UpdateScore(int score)
    {
        text.text = "Score: " + score;
        if (tweener)
            tweener.Tween(text.transform);
    }
}
