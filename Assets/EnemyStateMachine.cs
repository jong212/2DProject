using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 현재 상태 저장
public class EnemyStateMachine : MonoBehaviour
{
    public EnemyState currentState { get; private set; }
    public void Initialize(EnemyState _startState)
    {
        currentState = _startState;
        currentState.Enter();
    }
   public void ChangeState(EnemyState _newState)
    {
        currentState.Exit();
        currentState = _newState;
        currentState.Enter();
    }
}
