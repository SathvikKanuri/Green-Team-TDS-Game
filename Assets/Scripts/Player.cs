using System.Collections;
using System.Xml.Serialization;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 7;
    private Vector2 direction;
    private Vector2 mousePosition;
    public Camera camera;
    public float health;
    public AudioSource lowHealth;
    public AudioSource Player_Death_sfx;
    public bool RapidOn;
    public GameObject death;
    public GameObject player;

    public Sprite regular;
    public Sprite hit;
    public SpriteRenderer sr;

    void Start()
    {
        GameObject.Find("/Canvas/Text").GetComponent<Score>().ResetScore();
        player = GameObject.Find("Triangle");
        death = GameObject.Find("city_mc_death_sheet_0");
        death.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("LowHealth", 1f, 2f);

        lowHealth = GameObject.Find("/Sounds/low_health_sfx").GetComponent<AudioSource>();
        Player_Death_sfx = GameObject.Find("/Sounds/Player_Death_sfx").GetComponent<AudioSource>();
        sr = GetComponent<SpriteRenderer>();
        regular = sr.sprite;
    }

    void FixedUpdate()
    {
        Move();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Move()
    {
        // Gets mouse position, converts it to an angle, and rotates player to face that position
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 look = mousePosition - rb.position;
        float rotation = ((Mathf.Atan2(look.y, look.x)) * 180) / Mathf.PI - 180;
        rb.rotation = (rotation);

        // Get user input and use it to move player
        Vector3 movement = rb.velocity;

        movement.x = (Input.GetAxisRaw("Horizontal") * speed);
        movement.y = (Input.GetAxisRaw("Vertical") * speed);

        if (Input.GetAxisRaw("Vertical") == 0)
        {
            movement.y = 0f;
        }
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            movement.x = 0f;
        }

        rb.velocity = movement;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && Score.score < 5000)
        {
            health -= 2;
            sr.sprite = hit;
            Invoke("ResetMat", .1f);
        }
        else if (collision.gameObject.CompareTag("Enemy") && Score.score < 15000)
        {
            health -= 4;
            sr.sprite = hit;
            Invoke("ResetMat", .1f);
        }
        else if (collision.gameObject.CompareTag("Enemy") && Score.score < 20000)
        {
            health -= 6;
            sr.sprite = hit;
            Invoke("ResetMat", .1f);
        }
        else if (collision.gameObject.CompareTag("Enemy") && Score.score < 25000)
        {
            health -= 8;
            sr.sprite = hit;
            Invoke("ResetMat", .1f);
        }
        else if (collision.gameObject.CompareTag("Enemy") && Score.score < 30000)
        {
            health -= 10;
            sr.sprite = hit;
            Invoke("ResetMat", .1f);
        }
        else if (collision.gameObject.CompareTag("Speed"))
        {
            speed = 12;
            Invoke("ResetSpeed", 10f);
        }
        else if (collision.gameObject.CompareTag("Health"))
        {
            if (health < 70)
            {
                health += 30;
            }
            else
            {
                health += 100 - health;
            }
        }
        else if (collision.gameObject.CompareTag("Rapid"))
        {
            RapidOn = true;
            Invoke("RapidOff", 8f);
        }

    }

    void LowHealth()
    {
        if (health < 31f)
        {
            lowHealth.Play();
            InvokeRepeating("hurtMat", 0.2f, 0.2f);
            InvokeRepeating("ResetMat", 0.1f, 0.2f);
        }
        else
        {
            lowHealth.Pause();
            CancelInvoke("hurtMat");
            CancelInvoke("ResetMat");
        }
    }

    private void ResetSpeed()
    {
        speed = 3;
        UnityEngine.Debug.Log("Normal Speed");
    }

    private void RapidOff()
    {
        RapidOn = false;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Scenes/GameOver");
    }

    public void OnDestroy()
    {
        Player_Death_sfx.Play();
        death.transform.position = player.transform.position;
        death.transform.rotation = player.transform.rotation;
        death.SetActive(true);
    }
    void ResetMat()
    {
        sr.sprite = regular;
    }

    void hurtMat()
    {
        sr.sprite = hit;
    }
}
