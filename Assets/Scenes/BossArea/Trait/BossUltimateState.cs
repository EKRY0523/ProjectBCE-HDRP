using UnityEngine;
[CreateAssetMenu(fileName = "BossUlt", menuName = "CharacterStates/Enemy/BossUlt")]

public class BossUltimateState : UltimateAttackState
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        statemachine.MBEvent?.Invoke(stateKey, "Ultimate");
        statemachine.MBEvent?.Invoke(stateKey, true);
    }

    public override void OnExit(Statemachine statemachine)
    {
        base.OnExit(statemachine);
        statemachine.MBEvent?.Invoke(stateKey, "Ultimate");
        statemachine.MBEvent?.Invoke(stateKey, false);
    }

    public override void OnUpdate(Statemachine statemachine)
    {
        base.OnUpdate(statemachine);

    }
}
