﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public void restartGame()
    {
        UnityEngine.Debug.Log("Changing Scene!");
        SceneManager.LoadScene(0);
    }

    public void controls()
    {
        UnityEngine.Debug.Log("Changing Scene!");
        SceneManager.LoadScene(3);
    }
    public void mainMenu()
    {
        UnityEngine.Debug.Log("Changing Scene!");
        SceneManager.LoadScene("Scenes/TitleScreen");
    }
}