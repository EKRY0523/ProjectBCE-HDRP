using UnityEngine;

[CreateAssetMenu(fileName = "MinoriIdleState", menuName = "CharacterStates/Minori/Idle")]
public class IdleState : CharacterState
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        //if (statemachine.ComponentsID.Length > 0)
        //{

        //    statemachine.EnableComp?.Invoke(statemachine.ComponentsID[0], false);
        //    statemachine.EnableComp?.Invoke(statemachine.ComponentsID[1], true);
        //}

        statemachine.MBEvent?.Invoke(null, "Idling");
        statemachine.MBEvent?.Invoke(null, true);
        //statemachine.MBEvent?.Invoke(stateKey, PlayerMovement.StateTransitioning.CanMove);
    }

    public override void OnExit(Statemachine statemachine)
    {
        base.OnExit(statemachine);
        statemachine.MBEvent?.Invoke(null, "Idling");
        statemachine.MBEvent?.Invoke(null, false);
    }

    public override void OnUpdate(Statemachine statemachine)
    {
        base.OnUpdate(statemachine);
    }
}
