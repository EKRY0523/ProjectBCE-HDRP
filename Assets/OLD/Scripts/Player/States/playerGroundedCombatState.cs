using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerGroundedCombatState : playerGroundedState
{
    public playerGroundedCombatState(OldPlayer player, OldStatemachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Player.startAnim(Player.playerAnimationData.combatParameterHash);
        Player.input.playerActions.Move.Disable();
        //Player.anim.applyRootMotion = true;
    }

    public override void Exit()
    {
        base.Exit();

        Player.stopAnim(Player.playerAnimationData.combatParameterHash);

        Player.input.playerActions.Move.Enable();
        //Player.anim.applyRootMotion = false;
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
