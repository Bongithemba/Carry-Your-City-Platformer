using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float groundDrag = 5f;
    
    private Rigidbody2D body;
    private bool isGrounded;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Ground check using raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.5f);
        isGrounded = hit.collider != null;

        // Horizontal movement
        float horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);

        // Jump only when grounded
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
        }
    }
}