using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    public float maxVelocity = 20; // Maximum speed player can go
    public float gravityScale = 1.5f; // Variable for gravity strength
    public float jumpAmount = 500;
    private float playerSpeed = 50; // Enables player to reach max speed fast enough
    private float movementX; // Stores horizontal movement


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
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse1))
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        // Apply increased gravity to Player
        rb.AddForce(Physics.gravity * (gravityScale - 1) * rb.mass);
        // Assign horizontal movement to its own Vector2
        Vector2 hMovement = new Vector2(movementX, 0);
        // Stop speed increasing indefinitely
        if (rb.linearVelocityX < maxVelocity && - rb.linearVelocityX > -maxVelocity)
        {
            // Apply force to Rigidbody
            rb.AddForce(hMovement * playerSpeed);
        }
    }
}
