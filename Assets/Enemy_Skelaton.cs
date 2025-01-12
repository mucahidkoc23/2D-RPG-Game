using UnityEngine;

public class Enemy_Skelaton : Entity
{
    bool isAttacking;

    [Header("Move info")]
    [SerializeField] private float moveSpeed;

    [Header("Player dedection")]
    [SerializeField] private float playerCheckDistance;
    [SerializeField] private LayerMask whatIsPlayer;
    private RaycastHit2D isPlayerDedected;
    override protected void Start()
    {
        base.Start();
    }

    override protected void Update()
    {
        base.Update();

        if (isPlayerDedected)
        {
            if (isPlayerDedected.distance > 1)
            {
                rb.linearVelocity = new Vector2(moveSpeed * 1.5f * facingDir, rb.linearVelocity.y);
                isAttacking = false;
            }
            else
            {
                isAttacking = true;
            }
        }

        if (!isGrounded || isWallDedected)
        {
            Flip();
        }

        Movement();
    }

    private void Movement()
    {
        if (!isAttacking)
            rb.linearVelocity = new Vector2(moveSpeed * facingDir, rb.linearVelocity.y);
    }

    protected override void CollisionChecks()
    {
        base.CollisionChecks();
        isPlayerDedected = Physics2D.Raycast(transform.position, Vector2.right, playerCheckDistance * facingDir, whatIsPlayer);
    }

    override protected void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + playerCheckDistance * facingDir, transform.position.y));
    }
}
