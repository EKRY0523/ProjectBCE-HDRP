using UnityEngine;

[CreateAssetMenu(fileName = "BladeOfConviction1", menuName = "CharacterStates/Kuroya/BasicAttack/BladeOfConviction1")]
public class BladeOfConviction1 : BladeOfConvictionBase
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        statemachine.MBEvent?.Invoke(stateKey, "AttackCount");
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
