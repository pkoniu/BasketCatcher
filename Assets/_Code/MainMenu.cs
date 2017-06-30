using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//PatrykKonior

public class MainMenu : MonoBehaviour
{
    public Button newGameButton;
    public Button quitGameButton;

    void Awake()
    {
        newGameButton.onClick.AddListener(SceneSwitcher.LoadGameplay);
        quitGameButton.onClick.AddListener(Application.Quit);
    }
}
