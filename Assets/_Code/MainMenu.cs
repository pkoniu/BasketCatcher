﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//PKonior
public class MainMenu : MonoBehaviour {
    public string gameplayLevelName;
    public Button newGameButton;
    public Button quitGameButton;

	// Use this for initialization
	void Start () {
        newGameButton.onClick.AddListener(NewGameButtonHandler);
        quitGameButton.onClick.AddListener(QuitGameButtonHandler);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void NewGameButtonHandler()
    {
        SceneManager.LoadScene(gameplayLevelName);
    }

    void QuitGameButtonHandler()
    {
        Application.Quit();
    }
}
