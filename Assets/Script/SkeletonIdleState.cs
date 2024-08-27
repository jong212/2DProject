using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIdleState : EnemyState
{
    Enemy_Skeleton enemy;

    //Enemy_Skeleton ������ �ŰԺ������� ù ��°�� �׹�° this�� �����µ� �޴��ʿ��� Enemy ��ü�� �������� �� ������ Enemy_Skeleton���� ���������� �޴��ʿ��� �Ʒ��� ���� ���� �����ѵ�
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
