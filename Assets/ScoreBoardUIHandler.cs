using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreBoardUIHandler : MonoBehaviour
{
    public Button returnButton;

    [SerializeField] private Text scoreTextPrefab;
    [SerializeField] private float scoreHeightIncrement;
    [SerializeField] private int fontSize;

    private void Start()
    {
        int playerCount = 0;
        foreach (ScoreEntry playerScore in DataManager.instance.scores)
        {
            Text newScoreText = NewScoreText();
            newScoreText.transform.position = new Vector3(
                newScoreText.transform.position.x, 
                newScoreText.transform.position.y + playerCount * scoreHeightIncrement);
            newScoreText.text = playerScore.Name + ": " + playerScore.Score;
            playerCount++;
        }
    }

    private Text NewScoreText()
    {
        Text newScoreText = Instantiate(scoreTextPrefab, gameObject.transform);

        newScoreText.color = Color.white;
        newScoreText.fontSize = fontSize;
        newScoreText.alignment = TextAnchor.MiddleCenter;
        newScoreText.horizontalOverflow = HorizontalWrapMode.Overflow;
        newScoreText.verticalOverflow = VerticalWrapMode.Overflow;

        return newScoreText;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}