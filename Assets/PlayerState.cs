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

    // Player.cs 의 Awake에서 초기화가 이루어지면 모든 상태는 PlayerState를 상속받는데 각 클래스의 생성자가 base 부모 생성자를 가져오도록 되어있고 데이터를 넣어 저장하도록 되어있음 
    // 생성자로 인해 초기화 되는 단게에서 아래 데이터를 넣어놔야 player.anim 이나 stateMachine.ChangeState(player.airState); 이런 상태 변경이 가능함
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
