using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    public string playerName;
    public List<ScoreEntry> scores = new List<ScoreEntry>();

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScoreBoard();
    }

    public void LoadScoreBoard()
    {
        string path = Application.persistentDataPath + "/scoreboard.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            scores.Clear();

            SaveData data = JsonUtility.FromJson<SaveData>(json);
            for (int i = 0; i < data.names.Count; i++)
            {
                ScoreEntry playerScore = new ScoreEntry(data.names[i], data.scores[i]);
                scores.Add(playerScore);
            }

            // sort the score list
            scores.Sort((a, b) => b.Score.CompareTo(a.Score));
        }
    }

    public void SaveScores()
    {
        SaveData data = new SaveData();
        foreach (ScoreEntry playerScore in scores)
        {
            data.names.Add(playerScore.Name);
            data.scores.Add(playerScore.Score);
        }

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/scoreboard.json", json);
    }

    public void AddScore(string name, int score)
    {
        ScoreEntry newScore = new ScoreEntry(name, score);
        scores.Add(newScore);
        scores.Sort((a, b) => b.Score.CompareTo(a.Score));

        if (scores.Count > 10)
        {
            scores.GetRange(0, 10);
        }
    }
}
