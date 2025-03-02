using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 8f;
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private Transform groundCheck;

    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        inputManager.OnMove.AddListener(MovePlayer);
        inputManager.OnJump.AddListener(Jump);
        rb = GetComponent<Rigidbody>();

        if (cameraTransform == null)
            cameraTransform = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        // Ground check using sphere cast
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);
    }

    private void MovePlayer(Vector2 direction)
    {
        Vector3 forward = cameraTransform.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 right = cameraTransform.right;
        right.y = 0;
        right.Normalize();

        Vector3 moveDirection = forward * direction.y + right * direction.x;
        Vector3 force = speed * Time.fixedDeltaTime * 100 * moveDirection;
        
        // Only apply movement force when grounded
        if(isGrounded)
            rb.AddForce(force, ForceMode.Force);
        else
            rb.AddForce(force * 0.5f, ForceMode.Force); // Reduced air control

        // Limit maximum horizontal speed
        Vector3 horizontalVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        if(horizontalVelocity.magnitude > speed)
        {
            horizontalVelocity = horizontalVelocity.normalized * speed;
            rb.linearVelocity = new Vector3(horizontalVelocity.x, rb.linearVelocity.y, horizontalVelocity.z);
        }
    }

    private void Jump()
    {
        if(isGrounded)
        {
            Debug.Log("Jump triggered!");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        else
        {
            Debug.Log("Not grounded!");
        }
    }

    // Visualize ground check sphere in editor
    private void OnDrawGizmos()
    {
        if(groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}