using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float health;
    public float damage;
    public GameObject player;
    public Rigidbody2D rb;
    public Vector2 PlayerDir;
    public Transform playerPos;

    private void Start()
    {
        player = GameObject.Find("Triangle");
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerDir = player.transform.position;
        Vector2 look = PlayerDir - rb.position;
        float rotation = ((Mathf.Atan2(look.y, look.x)) * 180) / Mathf.PI - 90f;
        rb.rotation = (rotation);

        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.fixedDeltaTime);

        if (health < 0f || health == 0f)
        {
            FindObjectOfType<Score>().IncreaseScore();
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") == false && collision.gameObject.CompareTag("Enemy") == false)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                health -= damage;
            }
        }
    }
}  