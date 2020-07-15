using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float force;
    public GameObject Bullet1;
    private GameObject bullet;
    public Transform barrel;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            bullet = Instantiate(Bullet1, barrel.position, barrel.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(barrel.up * force, ForceMode2D.Impulse);
        }
    }
}
