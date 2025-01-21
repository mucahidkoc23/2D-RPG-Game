using UnityEngine;

public class PlayerPrimaryAttack : PlayerState
{
    private int comboCounter;
    private float lastTimeAttacked;
    private float comboWindow = 2;
    public PlayerPrimaryAttack(PlayerStateMachine stateMachine, Player player, string animBoolName) : base(stateMachine, player, animBoolName)
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

    }
    public override void Update()
    {
        base.Update();

        if (triggerCalled)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }
    public override void Exit()
    {
        base.Exit();

        comboCounter++;
        lastTimeAttacked = Time.deltaTime;
    }
}
