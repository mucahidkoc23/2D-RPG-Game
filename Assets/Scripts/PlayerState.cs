using System;
using UnityEngine;

public class PlayerState
{
    protected float xInput;
    protected float yInput;
    protected PlayerStateMachine stateMachine;
    protected Player player;
    public Rigidbody2D rb;

    private string animBoolName;

    protected float stateTimer;
    protected bool triggerCalled;

    public PlayerState(PlayerStateMachine stateMachine, Player player, String animBoolName)
    {
        this.stateMachine = stateMachine;
        this.player = player;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName, true);
        rb = player.rb;
        triggerCalled = false;
    }
    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        player.anim.SetFloat("yVelocity", rb.linearVelocity.y);
    }
    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
    }

    public virtual void AnimationFinishTrigger() 
    {
        triggerCalled = true;
    }

}
