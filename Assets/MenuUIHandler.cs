using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public InputField nameInputField;

    private void Start()
    {
        nameInputField.onValueChanged.AddListener(delegate { NewNameInserted(); });
    }

    public void NewNameInserted()
    {
        DataManager.instance.playerName = nameInputField.text;
    }

    public void StartNew()
    {
        if (nameInputField.text != "")
        {
            SceneManager.LoadScene(1);
        }
    }

    public void ToScoreBoard()
    {
        SceneManager.LoadScene(2);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}