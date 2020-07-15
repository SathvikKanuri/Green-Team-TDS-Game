using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public Object enemy;

    void Start()
    {
        spawnPoint = this.GetComponent<Transform>();
        InvokeRepeating("Spawn", 8.0f, 3.0f);
    }

    void Spawn()
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
    }
}
