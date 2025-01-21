using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Attack Details")]
    public float[] attackMovement;

    public bool isBusy { get; private set; }

    [Header("Player Info")]
    public float moveSpeed = 8f;
    public float jumpForce;

    [Header("Dash Info")]
    [SerializeField] private float dashCooldown;
    private float dashUsageTimer;
    public float dashSpeed;
    public float dashDuration;
    public float dashDir { get; private set; }

    [Header("Collision Info")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private LayerMask whatIsGround;

    public int FacingDir { get; private set; } = 1;
    public bool FacingRight { get; private set; }
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerAirState AirState { get; private set; }
    public PlayerDashState DashState { get; private set; }
    public PlayerWallSlideState WallSlide { get; private set; }
    public PlayerWallJumpState WallJump { get; private set; }
    public PlayerPrimaryAttackState PrimaryAttack { get; private set; }
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(StateMachine, this, "Idle");
        MoveState = new PlayerMoveState(StateMachine, this, "Move");
        JumpState = new PlayerJumpState(StateMachine, this, "Jump");
        AirState = new PlayerAirState(StateMachine, this, "Jump");
        DashState = new PlayerDashState(StateMachine, this, "Dash");
        WallSlide = new PlayerWallSlideState(StateMachine, this, "WallSlide");
        WallJump = new PlayerWallJumpState(StateMachine, this, "Jump");
        PrimaryAttack = new PlayerPrimaryAttackState(StateMachine, this, "Attack");
    }

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        StateMachine.CurrentState.Update();
        CheckforDashInput();
    }

    public void ZeroVelecity() => rb.linearVelocity = new Vector2(0, 0);
    public IEnumerator BusyFor(float seconds)
    {
        isBusy = true;
        yield return new WaitForSeconds(seconds);
        isBusy = false;

    }

    public void AnimationTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
    private void CheckforDashInput()
    {
        if (IsWallDetected())
        {
            return;
        }
        dashUsageTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashUsageTimer < 0)
        {
            dashUsageTimer = dashCooldown;
            dashDir = Input.GetAxisRaw("Horizontal");
            if (dashDir == 0)
            {
                dashDir = FacingDir;
            }
            StateMachine.ChangeState(DashState);
        }

    }

    public void SetVelocity(float xVelocity, float yVelocity)
    {
        rb.linearVelocity = new Vector2(xVelocity, yVelocity);
        FlipController(xVelocity);
    }

    public bool IsGroundedDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    public bool IsWallDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * FacingDir, wallCheckDistance, whatIsGround);

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
    }

    public void Flip()
    {
        FacingDir = FacingDir * -1;
        FacingRight = !FacingRight;
        transform.Rotate(0, 180, 0);
    }

    public void FlipController(float x)
    {
        if (x > 0 && FacingRight)
        {
            Flip();
        }
        else if (x < 0 && !FacingRight)
        {
            Flip();
        }
    }

}
