using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float force;
    public GameObject Bullet1;
    public GameObject Bullet2;
    private GameObject bullet;
    public Transform barrel;
    public AudioSource Shoot_sfx;
    public bool RapidOn;

    private void Start()
    {
        Shoot_sfx = GameObject.Find("/Sounds/Shoot_sfx").GetComponent<AudioSource>();
    }

    void Update()
    {
        RapidOn = GameObject.Find("Triangle").GetComponent<Player>().RapidOn;
        if (RapidOn == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                bullet = Instantiate(Bullet1, barrel.position, barrel.rotation);
                Shoot_sfx.Play();
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(barrel.up * force, ForceMode2D.Impulse);
            }
        }
        else if (RapidOn == true)
        {
            if (Input.GetButton("Fire1"))
            {
                bullet = Instantiate(Bullet2, barrel.position, barrel.rotation);
                Shoot_sfx.Play();
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.AddForce(barrel.up * force, ForceMode2D.Impulse);
            }
        }
    }
}
