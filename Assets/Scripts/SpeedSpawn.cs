using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedSpawn : MonoBehaviour
{
    public Transform spawnPoint;
    public Object Speed;

    void Start()
    {
        spawnPoint = this.GetComponent<Transform>();
        InvokeRepeating("Spawn", 15.0f, Random.Range(40f, 70f));
    }

    void Spawn()
    {
        Instantiate(Speed, spawnPoint.position, spawnPoint.rotation);
    }
}