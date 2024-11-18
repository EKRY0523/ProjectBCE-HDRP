using UnityEngine;
[CreateAssetMenu(fileName = "IgnitionState", menuName = "CharacterStates/Kuroya/Dodge/IgnitionState")]

public class IgnitionState : CharacterDodgeState
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        statemachine.MBEvent?.Invoke(stateKey, "Dodge");
        statemachine.MBEvent?.Invoke(stateKey, (int)1);
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
