using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct ScoreEntry
{
    public string Name { get; set; }
    public int Score { get; set; }

    public ScoreEntry(string name, int score)
    {
        this.Name = name;
        this.Score = score;
    }
}
