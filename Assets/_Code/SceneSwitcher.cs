using UnityEngine.SceneManagement;

//PatrykKonior

public static class SceneSwitcher
{
    public const string SCN_MAIN_MENU = "mainmenu_PKonior";
    public const string SCN_GAMEPLAY = "gameplay_PKonior";
    public const string SCN_HIGHSCORES = "highscore_PKonior";

    public static void LoadMainMenu()
    {
        SceneManager.LoadScene(SCN_MAIN_MENU);
    }
    public static void LoadGameplay()
    {
        SceneManager.LoadScene(SCN_GAMEPLAY);
    }
    public static void LoadHighScores()
    {
        SceneManager.LoadScene(SCN_HIGHSCORES);
    }
}