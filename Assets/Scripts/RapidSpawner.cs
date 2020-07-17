using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidSpawner : MonoBehaviour
{
    public Transform spawnPoint;
    public Object Rapid;

    void Start()
    {
        spawnPoint = this.GetComponent<Transform>();
        InvokeRepeating("Spawn", 18.0f, Random.Range(40f, 70f));
    }

    void Spawn()
    {
        Instantiate(Rapid, spawnPoint.position, spawnPoint.rotation);
    }
}
