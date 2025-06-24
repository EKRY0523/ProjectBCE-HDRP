using UnityEngine;
[CreateAssetMenu(fileName = "CounterStrike", menuName = "CharacterStates/Minori/Dodge/CounterStrike")]

public class MinoriCounterStrikeState : MinoriDodgeState
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        statemachine.MBEvent?.Invoke(stateKey, "DodgeType");
        statemachine.MBEvent?.Invoke(stateKey, (int)0);
    }

    public override void OnExit(Statemachine statemachine)
    {
        base.OnExit(statemachine);
    }

    public override void OnUpdate(Statemachine statemachine)
    {
        base.OnUpdate(statemachine);
    }
}
