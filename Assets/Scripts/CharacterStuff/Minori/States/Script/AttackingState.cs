using UnityEngine;

public class AttackingState : State
{
    public override void OnEnter(Statemachine statemachine)
    {
        statemachine.timeInState = 0;
        if (statemachine.ComponentsID.Length > -1)
        {
            statemachine.EnableComp?.Invoke(statemachine.ComponentsID[0], true);
            statemachine.EnableComp?.Invoke(statemachine.ComponentsID[1], false);
        }
        statemachine.MBEvent?.Invoke(stateKey, "Attacking");
        statemachine.MBEvent?.Invoke(stateKey, true);
        //statemachine.MBEvent?.Invoke(stateKey, PlayerMovement.StateTransitioning.inAttack);
    }

    public override void OnExit(Statemachine statemachine)
    {
        statemachine.MBEvent?.Invoke(stateKey, "Attacking");
        statemachine.MBEvent?.Invoke(stateKey, false);
    }

    public override void OnUpdate(Statemachine statemachine)
    {
        if (statemachine.timeInState < maxTimeInState)
        {
            statemachine.timeInState += Time.deltaTime;
        }
        else
        {
            statemachine.ChangeState(statemachine.startingState);
        }

    }
}
