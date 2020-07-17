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
    public AudioSource EnemyDeath;
    public int spawnedEnemies;
    public UnityEngine.Object explosionRef;

    public Sprite regular;
    public Sprite hit;
    public SpriteRenderer sr;

    private void Start()
    {
        explosionRef = Resources.Load("Explosion");
        player = GameObject.Find("Triangle");
        rb = GetComponent<Rigidbody2D>();
        EnemyDeath = GameObject.Find("/Sounds/Enemy_death").GetComponent<AudioSource>();

        sr = GetComponent<SpriteRenderer>();

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
            GameObject explosion = (GameObject)Instantiate(explosionRef);
            explosion.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            Destroy(gameObject);
            EnemyDeath.Play();
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") == false && collision.gameObject.CompareTag("Enemy") == false)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                sr.sprite = hit;
                Invoke("ResetMat", .1f);
                health -= damage;
                GameObject.Find("GameObject").GetComponent<SpawnedEnemies>().DecreaseEnemyCount();
            }
        }
    }

    void ResetMat()
    {
        sr.sprite = regular;
    }
}  