using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;

    protected Rigidbody2D rb;

    protected float xInput;
    protected float yInput;
    private string animBoolName;

    protected float stateTimer;

    // Player.cs �� Awake���� �ʱ�ȭ�� �̷������ ��� ���´� PlayerState�� ��ӹ޴µ� �� Ŭ������ �����ڰ� base �θ� �����ڸ� ���������� �Ǿ��ְ� �����͸� �־� �����ϵ��� �Ǿ����� 
    // �����ڷ� ���� �ʱ�ȭ �Ǵ� �ܰԿ��� �Ʒ� �����͸� �־���� player.anim �̳� stateMachine.ChangeState(player.airState); �̷� ���� ������ ������
    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName )
    {
        this.player = _player;

        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName, true);
        rb = player.rb;
    }
    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
        Debug.Log(stateTimer + "PlayerState");
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");
        player.anim.SetFloat("yVelocity", rb.velocity.y);
    }
    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
    }
}
