using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(PlayerStateMachine stateMachine, Player player, string animBoolName) : base(stateMachine, player, animBoolName)
    {
    }
    public override void Enter()
    {
        base.Enter();
        stateTimer = player.dashDuration;
    }
    public override void Exit()
    {
        base.Exit();
        player.SetVelocity(0, rb.linearVelocity.y);
    } 
    public override void Update()
    {
        base.Update();

        player.SetVelocity(player.dashSpeed * player.dashDir, 0);
        Debug.Log(player.FacingDir);

        if (stateTimer < 0)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }
}
