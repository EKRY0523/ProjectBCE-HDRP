using UnityEngine;

public class PathOfDeliveranceStateBase : BasicAttackState
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        statemachine.MBEvent?.Invoke(stateKey, "BasicAttackType");
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
