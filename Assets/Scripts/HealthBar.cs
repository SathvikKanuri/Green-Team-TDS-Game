using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public float health;
    public Slider slider;

    void Start()
    {
        health = GameObject.Find("Triangle").GetComponent<Player>().health;
        slider = GetComponent<Slider>();
        slider.maxValue = health;
        slider.minValue = 0f;
        slider.value = health;
    }

    void Update()
    {
        health = GameObject.Find("Triangle").GetComponent<Player>().health;
        slider.value = health;
    }
}
