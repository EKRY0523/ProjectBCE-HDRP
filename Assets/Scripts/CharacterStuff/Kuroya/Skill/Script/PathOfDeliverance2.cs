using UnityEngine;
[CreateAssetMenu(fileName = "PoD2", menuName = "CharacterStates/Kuroya/BasicAttack/PoD2")]
public class PathOfDeliverance2 : PathOfDeliveranceStateBase
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
