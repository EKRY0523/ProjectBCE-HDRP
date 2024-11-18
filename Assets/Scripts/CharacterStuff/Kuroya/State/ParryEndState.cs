using UnityEngine;
[CreateAssetMenu(fileName = "ParryEndState", menuName = "CharacterStates/Kuroya/Dodge/ParryEndState")]
public class ParryEndState : CharacterDodgeState
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        statemachine.MBEvent?.Invoke(stateKey, "Success");
        statemachine.MBEvent?.Invoke(stateKey, false);
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