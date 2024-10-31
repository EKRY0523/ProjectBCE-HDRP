using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerRunState : playerGroundedState
{
    public playerRunState(OldPlayer player, OldStatemachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Player.startAnim(Player.playerAnimationData.RunParameterHash);
    }

    public override void Exit()
    {
        base.Exit();
        Player.stopAnim(Player.playerAnimationData.RunParameterHash);
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
