using UnityEngine;

[CreateAssetMenu(fileName = "BladeOfConviction2", menuName = "CharacterStates/Kuroya/BasicAttack/BladeOfConviction2")]
public class BladeOfConviction2 : BasicAttackState
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        statemachine.timeInState = 0;
        statemachine.MBEvent?.Invoke(stateKey, "AttackCount");
        statemachine.MBEvent?.Invoke(stateKey, (int)1);
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
