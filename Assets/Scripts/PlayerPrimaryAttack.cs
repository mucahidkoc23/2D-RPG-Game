using UnityEngine;

public class PlayerPrimaryAttackState : PlayerState
{
    private int comboCounter;
    private float lastTimeAttacked;
    private float comboWindow = 2;
    public PlayerPrimaryAttackState(PlayerStateMachine stateMachine, Player player, string animBoolName) : base(stateMachine, player, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        if (comboCounter > 2 || Time.deltaTime >= lastTimeAttacked + comboWindow)
        {
            comboCounter = 0;
        }

        player.anim.SetInteger("ComboCounter", comboCounter);

        float attackDir = player.FacingDir;

        if (xInput != 0)
        {
            attackDir = xInput;
        }

        player.SetVelocity(player.attackMovement[comboCounter] * attackDir, rb.linearVelocity.y);
        stateTimer = .1f;

    }
    public override void Update()
    {
        base.Update();

        if (triggerCalled)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        if (stateTimer < 0)
        {
            player.ZeroVelecity();
        }
    }
    public override void Exit()
    {
        base.Exit();

        player.StartCoroutine("BusyFor", .15f);
        comboCounter++;
        lastTimeAttacked = Time.deltaTime;
    }
}
