using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonGroundedState : EnemyState
{
    protected Enemy_Skeleton enemy;
    protected Transform player;
    //Enemy_Skeleton 생성자 매게변수에서 첫 번째랑 네번째 this로 보내는데 받는쪽에서 Enemy 객체로 받을건지 그 하위인 Enemy_Skeleton으로 받을건지는 받는쪽에서 아래와 같이 결정 가능한듯

    public SkeletonGroundedState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.Find("Player").transform;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (enemy.IsPlayerDetected() || Vector2.Distance(enemy.transform.position, player.position) <2)
            stateMachine.ChangeState(enemy.battleState);
    }
}
