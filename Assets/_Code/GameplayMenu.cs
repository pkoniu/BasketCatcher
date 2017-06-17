using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayMenu : MonoBehaviour {
    public string gameplayLevelName;
    public Button backToMainManuButton;

    // Use this for initialization
    void Start()
    {
        backToMainManuButton.onClick.AddListener(BackToMainMenuButtonHandler);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void BackToMainMenuButtonHandler()
    {
        SceneManager.LoadScene(gameplayLevelName);
    }
}
