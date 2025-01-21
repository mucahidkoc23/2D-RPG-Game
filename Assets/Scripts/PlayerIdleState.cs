using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(PlayerStateMachine stateMachine, Player player, string animBoolName) : base(stateMachine, player, animBoolName)
    {

    }
    public override void Enter()
    {
        base.Enter();
        player.ZeroVelecity();
    }
    public override void Update()
    {
        base.Update();
        if (xInput == player.FacingDir && player.IsWallDetected())
        {
            return;
        }
        if (xInput != 0 && !player.isBusy)
        {
            stateMachine.ChangeState(player.MoveState);
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}
