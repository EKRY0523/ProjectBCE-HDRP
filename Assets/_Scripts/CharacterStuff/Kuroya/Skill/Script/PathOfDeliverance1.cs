using UnityEngine;
[CreateAssetMenu(fileName = "PoD1", menuName = "CharacterStates/Kuroya/BasicAttack/PoD1")]
public class PathOfDeliverance1 : PathOfDeliveranceStateBase
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
