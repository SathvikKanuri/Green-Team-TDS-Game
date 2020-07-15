using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed = 5.0f;
    private Vector2 direction;
    private Vector2 mousePosition;
    public Camera camera;
    public float health;

    void Start()
    {
        InvokeRepeating("Regen", 7f, 5f);
        rb = GetComponent<Rigidbody2D>();
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
        float rotation = ((Mathf.Atan2(look.y, look.x)) * 180) / Mathf.PI - 90.0f;
        rb.rotation = (rotation);

        // Get user input and use it to move player
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb.velocity = new Vector2(direction.x * speed * Time.deltaTime, direction.y * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") == false)
        {
            health -= 2;
        }
    }

    void Regen()
    {
        if (health + 4 < 100)
        {
            health += 4;
        }
    }
}
