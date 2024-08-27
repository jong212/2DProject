using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIdleState : EnemyState
{
    Enemy_Skeleton enemy;

    //Enemy_Skeleton 생성자 매게변수에서 첫 번째랑 네번째 this로 보내는데 받는쪽에서 Enemy 객체로 받을건지 그 하위인 Enemy_Skeleton으로 받을건지는 받는쪽에서 아래와 같이 결정 가능한듯
    public SkeletonIdleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_Skeleton _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    { 
        enemy = _enemy;
    }
    public override void Enter()
    {
        base.Enter();
        stateTimer = enemy.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
            stateMachine.ChangeState(enemy.moveState);
    }

    // Start is called before the first frame update

}
