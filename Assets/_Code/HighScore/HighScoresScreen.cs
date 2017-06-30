using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HighScoresScreen : MonoBehaviour {
    [Header("Prefabs")]
    public TableRow highScoreTableRow;

    [Header("Internal Refs")]
    public Button newGameButton;
    public Button menuButton;

    public Transform highScoreTable;

    public HighScoreCollection highScores;

    public NewHighScoreOverlay newHighScoreOverlay;

    // Use this for initialization
    void Start () {
        newHighScoreOverlay.gameObject.SetActive(false);
        newHighScoreOverlay.Show(123, NameSubmitted);
        LoadTable();
	}

    public void NameSubmitted(string name)
    {
        highScores.records.Add(new HighScoreRecord() { name = name, score = 123 });
        highScores.records = highScores.records.OrderByDescending(x => x.score).Take(10).ToList();
        //SaveHighScores();
        LoadTable();
    }

    private void LoadTable()
    {
        highScoreTable.gameObject.SetActive(true);
        foreach (var hsr in highScores.records)
        {
            Debug.Log(hsr.name + " : " + hsr.score);
            var ins = Instantiate(highScoreTableRow, highScoreTable) as TableRow;
            ins.Load(hsr.name, hsr.score);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
