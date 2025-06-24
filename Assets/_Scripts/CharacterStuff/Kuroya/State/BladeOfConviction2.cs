using UnityEngine;

[CreateAssetMenu(fileName = "BladeOfConviction2", menuName = "CharacterStates/Kuroya/BasicAttack/BladeOfConviction2")]
public class BladeOfConviction2 : BladeOfConvictionBase
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        statemachine.MBEvent?.Invoke(stateKey, "AttackCount");
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
