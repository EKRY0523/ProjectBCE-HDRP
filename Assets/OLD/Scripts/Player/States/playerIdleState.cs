using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerIdleState : playerGroundedState
{
    public playerIdleState(OldPlayer player, OldStatemachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Player.startAnim(Player.playerAnimationData.IdleParameterHash);
        Player.rb.linearVelocity = Vector3.zero;
    }

    public override void Exit()
    {
        base.Exit();
        Player.stopAnim(Player.playerAnimationData.IdleParameterHash);
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void Update()
    {
        base.Update();
    }
}
