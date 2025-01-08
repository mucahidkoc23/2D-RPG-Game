using UnityEngine;
using UnityEngine.Animations;

public class Learn : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public float xInput;
    private float movement = 4;
    private float jump = 5;
    public bool facingRight = true;

    [Header("Collision Info")]
    private bool isGrounded;
    [SerializeField] private float groundedCheckDistance;
    [SerializeField] private LayerMask whatIsGorunded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        CheckInput();
        CollisionChecks();
        FlipController();
        AnimatorController();
    }

    private void CollisionChecks()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundedCheckDistance, whatIsGorunded);
    }

    private void CheckInput()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void Movement()
    {
        rb.linearVelocity = new Vector2(xInput * movement, rb.linearVelocity.y);
    }

    private void AnimatorController()
    {
        bool isMoving = rb.linearVelocity.x != 0;

        anim.SetBool("isMove", isMoving);
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jump);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }

    private void FlipController()
    {
        if (facingRight && rb.linearVelocity.x < 0)
        {
            Flip();
        }
        else if (!facingRight && rb.linearVelocity.x > 0)
        {
            Flip();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x, transform.position.y - groundedCheckDistance));
    }
}
