using UnityEngine;
using UnityEngine.Animations;

public class Learn : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public float xInput;
    [SerializeField] private float movement = 8;
    [SerializeField] private float jump = 8;
    public bool facingRight = true;

    [Header("Dash info")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDruration;
    private float dashTime;
    [SerializeField] private float dashCooldown;
    private float dashCooldownTimer;


    [Header("Collision info")]
    [SerializeField] private float groundedCheckDistance;
    [SerializeField] private LayerMask whatIsGorunded;
    private bool isGrounded;

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
        dashTime -= Time.deltaTime;
        dashCooldownTimer -= Time.deltaTime;

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
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DashAbility();
        }
    }

    private void DashAbility()
    {
        if (dashCooldownTimer < 0)
        {
            dashCooldownTimer = dashCooldown;
            dashTime = dashDruration;
        }
    }

    private void Movement()
    {
        if (dashTime > 0)
        {
            rb.linearVelocity = new Vector2(xInput * dashSpeed, 0);
        }
        else
        {
            rb.linearVelocity = new Vector2(xInput * movement, rb.linearVelocity.y);
        }
    }

    private void AnimatorController()
    {
        bool isMoving = rb.linearVelocity.x != 0;

        anim.SetFloat("yVelocity", rb.linearVelocity.y);
        anim.SetBool("isMove", isMoving);
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isDashing", dashTime > 0);
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
