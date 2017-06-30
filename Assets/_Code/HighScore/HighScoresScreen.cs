using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.IO;

//PatrykKonior

public class HighScoresScreen : MonoBehaviour
{
    public TableRow tableRowPrefab;
    public Button newGameButton;
    public Button menuButton;
    public NewHighScoreOverlay newHighScoreOverlay;
    public Transform table;

    BasketCatcherCore basketCatcherCore;
    const string HIGHSCORES_FILENAME = "highscores.json";
    HighScoreCollection highScoreCollection;
    int newHighScore;

    void Start()
    {
        newHighScoreOverlay.gameObject.SetActive(false);
        newGameButton.onClick.AddListener(SceneSwitcher.LoadGameplay);
        menuButton.onClick.AddListener(SceneSwitcher.LoadMainMenu);
        table.gameObject.SetActive(false);

        basketCatcherCore = BasketCatcherCore.instance;
        newGameButton.gameObject.SetActive(basketCatcherCore.justLost);

        LoadHighScores();

        if (basketCatcherCore.justLost)
        {
            newHighScore = BasketCatcherCore.instance.lastScore;

            var minRecordScore = 0;
            if (highScoreCollection.records.Count >= 10)
            {
                minRecordScore = highScoreCollection.records.Select(x => x.score).Min();
            }

            if (newHighScore > minRecordScore)
            {
                newHighScoreOverlay.Show(newHighScore, NameSubmitted);
            }
            else
            {
                LoadTable();
            }
            basketCatcherCore.ConsumeScore();
        }
        else
        {
            LoadTable();
        }
    }

    public void LoadHighScores()
    {
        var p = MakePath();
        if (File.Exists(p))
        {
            highScoreCollection = JsonUtility.FromJson<HighScoreCollection>(File.ReadAllText(p));
        }
        else
        {
            highScoreCollection = new HighScoreCollection();
            highScoreCollection.records = new List<HighScoreRecord>();
        }
    }

    public void NameSubmitted(string name)
    {
        highScoreCollection.records.Add(new HighScoreRecord() { name = name, score = newHighScore });
        highScoreCollection.records = highScoreCollection.records.OrderByDescending(x => x.score).Take(10).ToList();
        SaveHighScores();
        LoadTable();
    }

    public void SaveHighScores()
    {
        File.WriteAllText(MakePath(), JsonUtility.ToJson(highScoreCollection, true));
    }

    public void LoadTable()
    {
        if (highScoreCollection.records.Count > 0)
            table.gameObject.SetActive(true);
        foreach (var hsr in highScoreCollection.records)
        {
            Debug.Log(hsr.name + " : " + hsr.score);
            var ins = Instantiate(tableRowPrefab, table) as TableRow;
            ins.Load(hsr.name, hsr.score);
        }
    }

    string MakePath()
    {
        return Application.persistentDataPath + "/" + HIGHSCORES_FILENAME;
    }
}
