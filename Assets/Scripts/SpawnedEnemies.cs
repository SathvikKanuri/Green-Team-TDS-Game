using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnedEnemies : MonoBehaviour
{
    public static int spawnedEnemies;
    public GameObject player;

    private void Start()
    {
        player = GameObject.Find("Triangle");
    }

    public void IncreaseEnemyCount()
    {
        spawnedEnemies += 1;
    }

    public void DecreaseEnemyCount()
    {
        spawnedEnemies -= 1;
    }

    public void SceneChange()
    {
        SceneManager.LoadScene("Scenes/GameOver");
    }

    private void Update()
    {
        if (player == null)
        {
            Invoke("SceneChange", 1.5f);
            enabled = false;
        }
    }
}
