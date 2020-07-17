using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score;
    public Color color;

    void Start()
    {
        GetComponent<Text>().text = score.ToString();
        color = GetComponent<Text>().color;
    }

    public void IncreaseScore()
    {
        score += 100;
        GameObject.Find("/Canvas/Text").GetComponent<Text>().text = score.ToString();
        GetComponent<Text>().color = Color.white;
        Invoke("resetColor", 0.3f);
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void resetColor()
    {
        GetComponent<Text>().color = color; 
    }
}
