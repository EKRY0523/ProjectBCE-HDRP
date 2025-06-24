using UnityEngine;
[CreateAssetMenu(fileName = "EnemyHeavyAttackState", menuName = "CharacterStates/Enemy/Ranged/EnemyHeavyAttackState")]
public class EnemyHeavyAttackState : EnemyAttackingState
{
    public override void OnEnter(Statemachine statemachine)
    {
        base.OnEnter(statemachine);
        statemachine?.MBEvent?.Invoke(null, "AttackType");
        statemachine?.MBEvent?.Invoke(null, (int)1);
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
