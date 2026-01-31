using System.Collections;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float maxVelocity = 10; // Maximum speed player can go
    public float gravityScale = 1.5f; // Variable for gravity strength
    public float jumpAmount = 20;
    private float playerSpeed = 50; // Enables player to reach max speed fast enough
    private float movementX; // Stores horizontal movement
    public int abilitySelector = 0;
    public int uses = 0;
    public Image star;
    public Sprite blankStar;
    private bool slammy = false;

    private bool isGrounded;


    void Awake()
    {
        // Assign Rigidbody 2D
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue movementValue)
    {
        // Assigns input values to a Vector2 and take the X value
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        // If no input detected slow player down
        if (movementVector.magnitude == 0)
        {
            rb.linearDamping = 3;
        }
        else
        {
            rb.linearDamping = 0;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded)
            {
                rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
                isGrounded = false;
            }
        }


        if (uses == 0)
        {
            star.sprite = blankStar;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (uses > 0)
            {
                if (abilitySelector == 1)
                {
                    gravityScale *= -1;
                    uses -= 1;
                }
                if (abilitySelector == 2)
                {
                    if (isGrounded == true)
                    {
                        slammy = false;
                    }
                    else
                    {
                        slammy = true;
                    }
                    rb.AddForce(Vector2.down * 30, ForceMode2D.Impulse);
                    uses -= 1; 
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (abilitySelector == 2)
            {
                if (uses > 0)
                {
                    rb.AddForce(Vector2.up * 25, ForceMode2D.Impulse);
                    uses -= 1;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        // Apply increased gravity to Player
        rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
        // Assign horizontal movement to its own Vector2
        Vector2 hMovement = new Vector2(movementX, 0);
        // Stop speed increasing indefinitely
        if (rb.linearVelocity.magnitude < maxVelocity)
        {
            // Apply force to Rigidbody
            rb.AddForce(hMovement * playerSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground")) {
            isGrounded = true;
        }
        if (collision.collider.CompareTag("BreakableFloor"))
        {
            if (slammy == true)
            {
                Destroy(collision.gameObject);
                slammy = false;
            }
        }
        if (collision.collider.CompareTag("Goal"))
        {
            SceneManager.LoadScene("Level Selection");
        }
    }

}
