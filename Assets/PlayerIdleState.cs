using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        rb.velocity = new Vector2();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();


        if (xInput == player.facingDir && player.IsWallDetected())
            return;
        // 움직이고 있으면 move로
        if (xInput != 0)
            stateMachine.ChangeState(player.moveState);
    }

    // Start is called before the first frame update

}
