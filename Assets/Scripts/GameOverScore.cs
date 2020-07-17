using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScore : MonoBehaviour
{
    public int score;

    void Update()
    {
        score = Score.score;
        GameObject.Find("/Canvas/Text").GetComponent<Text>().text = "Your Score: " + score.ToString();
    }
}
