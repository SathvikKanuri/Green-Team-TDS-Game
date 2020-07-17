using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public Object Health;

    void Start()
    {
        spawnPoint = this.GetComponent<Transform>();
        InvokeRepeating("Spawn", 18.0f, Random.Range(40f, 70f));
    }

    void Spawn()
    {
        Instantiate(Health, spawnPoint.position, spawnPoint.rotation);
    }
}
