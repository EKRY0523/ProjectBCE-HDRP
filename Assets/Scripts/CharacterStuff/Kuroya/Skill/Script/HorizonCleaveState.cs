using UnityEngine;
[CreateAssetMenu(fileName = "HorizonCleaveState", menuName = "CharacterStates/Kuroya/Ultimate/HorizonCleave")]

public class HorizonCleaveState : UltimateAttackState
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        statemachine.MBEvent?.Invoke(stateKey, "UltimateType");
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
