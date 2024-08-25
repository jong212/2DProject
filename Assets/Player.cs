using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Player.cs             ����: �÷��̾� ĳ���Ϳ� ���� ���¸� �����ϴ� �� // �ӵ���,������ �� �ֿ� ������ ���⼭ ����!
// PlayerState.cs        ����: ���º��� �÷��̾ � �ൿ�� �ؾ� �ϴ����� �����ϴ� �⺻ Ŭ����. �� Ŭ������ !!���� ����!!�� �����ϰ�, �� ����(Idle, Move, Jump ��)�� �̸� ��ӹ޾� ������ ������ �߰��մϴ�.
// PlayerStateMachine.cs ����: �÷��̾��� ���� ���¸� �����ϰ�, ���¸� ��ȯ�ϴ� ����� ����մϴ�.
public class Player : MonoBehaviour
{
    [Header("Move info")]
    public float moveSpeed = 8f;
    public float jumpForce = 12f;

    [Header("Collision info")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private float wallCheckDistance;
    [SerializeField] private LayerMask whatIsGround;

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
    public bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector3(wallCheck.position.x + wallCheckDistance,wallCheck.position.y));
    }
}
