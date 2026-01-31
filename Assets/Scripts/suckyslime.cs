using UnityEngine;
using System.Collections;

public class uglygoblin : MonoBehaviour
{
    Vector3 startpos;
    private float speed = 3f;
    private float jumpAmount = 200;
    private float gravityScale = 1.5f;
    private int counter;
    private bool isGrounded;
    public Transform player;
    Rigidbody2D rb;
    private int health = 3;
    public GameObject enemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startpos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(enemy);
            player.GetComponent<PlayerController>().uses = 3;
            player.GetComponent<PlayerController>().abilitySelector = 2;
        }
        Vector3 displacement = player.position - transform.position;
        displacement = displacement.normalized;
        if (Vector2.Distance(player.position, transform.position) > 1.0f)
        {
            transform.position += (displacement * speed * Time.deltaTime);

        }
        Vector2 distJump = new Vector2(displacement.x, displacement.y);
        
    }

    private void FixedUpdate()
    {
        rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Force);
            isGrounded = false;
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            transform.position = startpos;
        }

        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.collider.CompareTag("Bullet"))
        {
            health -= 1;
            Destroy(collision.gameObject);
        }
    }
}
