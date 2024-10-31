using UnityEngine;

[CreateAssetMenu(fileName = "MinoriIdleState", menuName = "CharacterStates/Minori/Idle")]
public class MinoriIdleState : State
{
    public override void OnEnter(Statemachine statemachine)
    {
        statemachine.MBEvent?.Invoke(null, "Idling");
        statemachine.MBEvent?.Invoke(null, true);
        statemachine.MBEvent?.Invoke(stateKey, PlayerMovement.StateTransitioning.CanMove);
    }

    public override void OnExit(Statemachine statemachine)
    {
        statemachine.MBEvent?.Invoke(null, "Idling");
        statemachine.MBEvent?.Invoke(null, false);
    }

    public override void OnUpdate(Statemachine statemachine)
    {
    }
}
