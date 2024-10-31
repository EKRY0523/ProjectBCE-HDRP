using UnityEngine;

public class AttackingState : State
{
    public override void OnEnter(Statemachine statemachine)
    {
        statemachine.timeInState = 0;
        statemachine.MBEvent?.Invoke(stateKey, "Attacking");
        statemachine.MBEvent?.Invoke(stateKey, true);
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
