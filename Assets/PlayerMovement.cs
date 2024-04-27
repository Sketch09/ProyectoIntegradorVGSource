using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 300f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpCount = 0;  // Counter to track the number of jumps made
    public int maxJumps = 2;    // Maximum number of jumps allowed (1 ground jump + 1 double jump)

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Horizontal Movement using A and D keys
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * speed, rb.velocity.y);

        // Jumping with Space key
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || jumpCount < maxJumps))
        {
            rb.velocity = new Vector2(rb.velocity.x, 0); // Resetting y velocity to make each jump consistent
            rb.AddForce(new Vector2(0, jumpForce));
            jumpCount++;
        }

        // Firing with left mouse click
        if (Input.GetMouseButtonDown(0)) // 0 is the button number for left click
        {
            Fire();
        }
    }

    void Fire()
    {
        // Implement your firing logic here
        Debug.Log("Fire!");
    }

    // Check if the player is touching the ground.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0;  // Reset jump count when the player touches the ground
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
