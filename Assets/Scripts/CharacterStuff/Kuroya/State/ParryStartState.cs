using UnityEngine;
[CreateAssetMenu(fileName = "ParryStartState", menuName = "CharacterStates/Kuroya/Dodge/ParryStartState")]
public class ParryStartState : CharacterDodgeState
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