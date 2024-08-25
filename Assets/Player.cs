using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Player.cs             ����: �÷��̾� ĳ���Ϳ� ���� ���¸� �����ϴ� PlayerStateMachine�� �ʱ�ȭ�ϰ�, �÷��̾��� ���� ���¸� ������Ʈ�մϴ�.
// PlayerStateMachine.cs ����: �÷��̾��� ���� ���¸� �����ϰ�, ���¸� ��ȯ�ϴ� ����� ����մϴ�.
// PlayerState.cs        ����: ���� ��ü�� �⺻ Ŭ�����Դϴ�. �� ���´� �� Ŭ������ ��ӹ޾� ���¿� ���� �ൿ�� �����մϴ�.
public class Player : MonoBehaviour
{
    [Header("Move info")]
    public float moveSpeed = 8f;
    public float jumpForce = 12f;
    #region Components
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    #endregion
    #region Statese
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState{ get; private set; }
    public PlayerAirState airState{ get; private set; }
    #endregion

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this,stateMachine,"Idle");
        moveState = new PlayerMoveState(this,stateMachine,"Move");
        jumpState = new PlayerJumpState(this,stateMachine,"Jump");
        airState = new PlayerAirState(this,stateMachine, "Jump");
    }
    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody2D>();
        stateMachine.Initialize(idleState);
    }

    private void Update()
    {
        stateMachine.currentState.Update();
    }
    public void SetVelocity(float _xVelocity,float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);
    }
}
