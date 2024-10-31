using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGroundedState : PlayerState
{
    public playerGroundedState(OldPlayer player, OldStatemachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Player.startAnim(Player.playerAnimationData.GroundedParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        Player.stopAnim(Player.playerAnimationData.GroundedParameterHash);
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
