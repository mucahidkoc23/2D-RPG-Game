using UnityEngine;

public class PlayerWallJumpState : PlayerState
{
    public PlayerWallJumpState(PlayerStateMachine stateMachine, Player player, string animBoolName) : base(stateMachine, player, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        stateTimer = .4f;
        player.SetVelocity(5 * -player.FacingDir, player.jumpForce);
    }
    public override void Update()
    {
        base.Update();
        if (player.IsGroundedDetected())
        {
            stateMachine.ChangeState(player.AirState);
        }
        if (stateTimer < 0)
        {
            stateMachine.ChangeState(player.AirState);
        }

    }
    public override void Exit()
    {
        base.Exit();
    }
}
