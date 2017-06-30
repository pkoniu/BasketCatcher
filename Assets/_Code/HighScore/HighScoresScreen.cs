using System.Collections;
using System.Collections.Generic;
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

    // Use this for initialization
    void Start () {
		foreach(var highScore in highScores.records)
        {
            Debug.Log(highScore.name + " " + highScore.score);
            foreach (var hsr in highScores.records)
            {
                var ins = Instantiate(highScoreTableRow, highScoreTable) as TableRow;
                ins.Load(hsr.name, hsr.score);
            }
            /*var newRow = Instantiate(highScoreTableRow);
            Text txtRef = newRow.transform.GetChild(0).GetComponent<Text>();
            txtRef.text = highScore.name;
            Text txtRef2 = newRow.transform.GetChild(1).GetComponent<Text>();
            txtRef2.text = highScore.score.ToString();
            newRow.transform.SetParent(highScoreTable.transform);*/
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
