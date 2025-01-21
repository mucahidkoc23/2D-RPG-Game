using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(PlayerStateMachine stateMachine, Player player, string animBoolName) : base(stateMachine, player, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(player.WallJump);
            return;
        }

        if (xInput != 0 && player.FacingDir != xInput)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        if (yInput < 0)
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y * .7f);

        }
        if (player.IsGroundedDetected())
        {
            stateMachine.ChangeState(player.IdleState);
        }

    }
}
