using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public Object enemy;
    public int spawnedEnemies;

    void Start()
    {
        spawnedEnemies = 11;
        spawnPoint = this.GetComponent<Transform>();
        InvokeRepeating("CheckAndSpawn", 8.0f, 3.0f);
    }

    void Update()
    {
        spawnedEnemies = SpawnedEnemies.spawnedEnemies;
    }

    void CheckAndSpawn()
    {
        if (spawnedEnemies <= 30)
        {
            Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
            GameObject.Find("GameObject").GetComponent<SpawnedEnemies>().IncreaseEnemyCount();
        }
    }
}
