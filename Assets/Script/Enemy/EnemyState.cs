using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 역할 : 적의 상태를 정의하는 베이스 클래스. 모든 상태 클래스들의 행동을 정의하는 기본 클래스.
// 이 클래스를 상속받은 자식클래스가 초기화 되면 자식 생성자가 부모 생성자를 호출한다는 사실을 기억해야 하고 자식 생성자가 받은 매게변수는 부모 생성자에게 전달 됨

public class EnemyState {
    protected EnemyStateMachine stateMachine;
    protected Enemy enemyBase;
    protected Rigidbody2D rb;

    private string animBoolName;


    protected float stateTimer;
    protected bool triggerCalled;

    public EnemyState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName)
    {
        this.enemyBase = _enemyBase;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
    }
    public virtual void Enter()
    {
        triggerCalled = false;
        rb = enemyBase.rb;
        enemyBase.anim.SetBool(animBoolName, true);


    }
    public virtual void Exit()
    {
        enemyBase.anim.SetBool(animBoolName, false);

    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}
