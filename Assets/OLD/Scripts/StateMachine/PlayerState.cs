using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : IState
{
    protected OldPlayer Player;
    protected OldStatemachine StateMachine;

    public PlayerState(OldPlayer player, OldStatemachine stateMachine)
    {
        this.Player = player;
        this.StateMachine = stateMachine;
    }

    public virtual void Enter()
    {
        //Debug.Log(GetType().Name);
    }

    public virtual void Exit()
    {
    }

    public virtual void HandleInput()
    {
    }

    public virtual void PhysicsUpdate()
    {
        
    }

    public virtual void Update()
    {
    }
}
