using System;
using UnityEngine;

public class PlayerState
{
    protected float xInput;
    protected PlayerStateMachine stateMachine;
    protected Player player;
    public Rigidbody2D rb;

    private string animBoolName;

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
    }
    public virtual void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        player.anim.SetFloat("yVelocity", rb.linearVelocity.y);
    }
    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
    }

}
