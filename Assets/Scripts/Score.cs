using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    void Start()
    {
        GetComponent<Text>().text = score.ToString();
    }

    public void IncreaseScore()
    {
        score += 100;
        GameObject.Find("/Canvas/Text").GetComponent<Text>().text = score.ToString();
    }
}
