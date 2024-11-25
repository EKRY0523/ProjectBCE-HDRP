using UnityEngine;
[CreateAssetMenu(fileName = "BossBasic", menuName = "CharacterStates/Enemy/BasicATTACK/state")]

public class BossBasic : BasicAttackState
{
    public int count;
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        statemachine.MBEvent?.Invoke(stateKey, "AttackCount");
        statemachine.MBEvent?.Invoke(stateKey, (int)count);
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
