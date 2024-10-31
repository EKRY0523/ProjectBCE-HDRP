using UnityEngine;

[CreateAssetMenu(fileName = "BladeOfConviction3", menuName = "CharacterStates/Kuroya/BasicAttack/BladeOfConviction3")]
public class BladeOfConviction3 : BasicAttackState
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        statemachine.timeInState = 0;
        statemachine.MBEvent?.Invoke(stateKey, "AttackCount");
        statemachine.MBEvent?.Invoke(stateKey, (int)2);
        statemachine.MBEvent?.Invoke(stateKey, PlayerMovement.StateTransitioning.inAttack);
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
