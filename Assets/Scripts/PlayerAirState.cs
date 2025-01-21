using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(PlayerStateMachine stateMachine, Player player, string animBoolName) : base(stateMachine, player, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();
        
        if (player.IsWallDetected())
        {
            stateMachine.ChangeState(player.WallSlide);
        }
        if (player.IsGroundedDetected())
        {
            stateMachine.ChangeState(player.IdleState);
        }
        if (xInput != 0)
        {
            player.SetVelocity(player.moveSpeed * .8f * xInput, rb.linearVelocity.y);
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}
