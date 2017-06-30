using UnityEngine;

//PatrykKonior

public class BasketCatcherCore : MonoBehaviour
{
    public static BasketCatcherCore instance
    {
        get; private set;
    }
    public bool justLost { get; private set; }
    public int lastScore { get; private set; }

    void Awake()
    {
        if (instance != null)
            DestroyImmediate(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void SubmitScore(int score)
    {
        justLost = true;
        lastScore = score;
    }

    public void ConsumeScore()
    {
        justLost = false;
    }
}