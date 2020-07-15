using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;
    public float distance = 10f;

    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, target.position.z - distance);

    }
}
