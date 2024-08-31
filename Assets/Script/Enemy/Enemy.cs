using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 역할 : 다양한 적 오브젝트가 가지는 공통 속성과 기본 행동을 정의하는 클래스.         - 상태 머신을 초기화하고 상태를 업데이트.
public class Enemy : Entity
{
    [SerializeField] protected LayerMask whatIsPlayer;

    [Header("Stunned info")]
    public float sturnDuration;
    public Vector2 stunDirection;
    protected bool canbeStunned;
    [SerializeField] protected GameObject counterImage;

    [Header("Move info")]
    public float moveSpeed;
    public float idleTime;
    public float battleTime;

    [Header("Attack info")]
    public float attackDistance;
    public float attackCoolDown;
    [HideInInspector] public float lastTimeAttacked;
    public EnemyStateMachine stateMachine { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();

    }

    public virtual void OpenCounterAttackWindow()
    {
        canbeStunned = true;
        counterImage.SetActive(true);
    }
    public virtual void CloseCounterAttackWindow()
    {
        canbeStunned = false;   
        counterImage.SetActive(false);
    }
    public virtual bool CanbeStunned()
    {
        if (canbeStunned)
        {
            CloseCounterAttackWindow();
            return true;
        }
        return false;
    }



    public virtual void AnimationFinishTrigger() => stateMachine.currentState.AnimationFinishTrigger();
    public virtual RaycastHit2D IsPlayerDetected() => Physics2D.Raycast(wallCheck.position, Vector2.right * facingDir,50,whatIsPlayer);
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + attackDistance * facingDir, transform.position.y));
    }
}
